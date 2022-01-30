using MKT.Business.Abstract;
using MKT.DataAccess.Model.AppointmentApiModel;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Constants;

namespace MKT.Business.Concrete
{
    public class AppointmentShopifyService : IAppointmentShopifyService
    {
        private readonly IOrderSingletonService _orderSingletonService;

        private readonly IHttpClientFactory _httpClientFactory;


        private const string API_KEY = "6fdc64b87b62fac4054ed87cf7e43795";
        private const string PASSWORD = "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";
        private const string BASE_URL = "@artmasterclassmosaic.myshopify.com/admin/api/2021-10";
        private const string ORDER_URL = "/orders.json";

        private readonly DateTime minDateDefault = DateTime.Now.AddDays(-1);
        private readonly DateTime maxDateDefault = DateTime.Now;
        private readonly int limitDefault = 10;

        public AppointmentShopifyService(IHttpClientFactory httpClientFactory, IOrderSingletonService orderSingletonService)
        {
            _httpClientFactory = httpClientFactory;
            _orderSingletonService = orderSingletonService;
        }

        public async Task<AppointmentApiModel> GetData()
        {
            var data = await GetData(limitDefault, minDateDefault, maxDateDefault);
            return data;
        }

        public async Task<AppointmentApiModel> GetData(int limit, DateTime min, DateTime max)
        {
            var url = $"https://{API_KEY}:{PASSWORD}{BASE_URL}{ORDER_URL}?limit={limit}&created_at_min={min.ToString("yyyy-MM-dd")}&created_at_max={max.ToString("yyyy-MM-dd")}";
            return await GetData(url);
        }

        public async Task<AppointmentApiModel> GetData(string url)
        {
            if (!url.Contains("page_info"))
            {
                url += "&status=any";
            }
            using var client = _httpClientFactory.CreateClient();
            var authenticationString = $"{API_KEY}:{PASSWORD}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(authenticationString));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            var response = await client.GetAsync(url);
            var responseJsonString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            AppointmentApiModel appointment = JsonSerializer.Deserialize<AppointmentApiModel>(responseJsonString);

            string link = null;
            if (response.Headers.TryGetValues("link", out IEnumerable<string> linkValues))
            {
                link = linkValues.FirstOrDefault();
            }

            var orderLocations = _orderSingletonService.GetList(null,o=> o.Location);
            if (appointment != null)
            {
                foreach (var order in appointment.Orders)
                {
                    var orderLocation = orderLocations.SingleOrDefault(o => o.OrderId == order.Id);
                    order.LocationOrder = orderLocation;
                }
            }
            if (string.IsNullOrEmpty(link)) return appointment;
            return GetWithRelString(appointment, link);
        }

        public async Task<OrderApiModel> GetOrder(long orderId)
        {
            var url = $"https://{API_KEY}:{PASSWORD}{BASE_URL}/orders/{orderId.ToString()}.json";
            using var client = _httpClientFactory.CreateClient();
            var authenticationString = $"{API_KEY}:{PASSWORD}";
            var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(authenticationString));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

            var response = await client.GetAsync(url);
            var responseJsonString = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            OrderApiModel order = JsonSerializer.Deserialize<OrderApiModel>(responseJsonString);
            return order;
        }

        private AppointmentApiModel GetWithRelString(AppointmentApiModel appointment, string link)
        {
            if (!string.IsNullOrEmpty(link))
            {
                var links = link.Split(",");
                foreach (var linkValue in links)
                {
                    var nextPosition = linkValue.IndexOf("rel=\"next\"");
                    var previousPosition = linkValue.IndexOf("rel=\"previous\"");
                    if (nextPosition != -1)
                    {
                        string nextLink = linkValue.Substring(0, nextPosition).Trim();
                        nextLink = nextLink.Substring(nextLink.IndexOf("<") + 1, nextLink.IndexOf(">") - 1);
                        appointment.NextLink = nextLink;
                    }

                    if (previousPosition != -1)
                    {
                        string previousLink = linkValue.Substring(nextPosition + 1).Trim();
                        previousLink = previousLink.Substring(previousLink.IndexOf("<") + 1, previousLink.IndexOf(">") - 1);
                        appointment.PreviousLink = previousLink;
                    }
                }
            }

            return appointment;
        }
    }

}
