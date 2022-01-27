using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using MKT.Business.Abstract;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentApiModel;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.DataAccess.Model.Core;
using Newtonsoft.Json;

namespace MKT.Business.Concrete.AppointmentsDB
{
    public class OrderService: EfEntityRepositoryBase<TblOrder, AppointmentContext>, IOrderService
    {
        private readonly IAppointmentShopifyService _appointmentShopifyService;

        private readonly IUserService _userService;

        public OrderService(IAppointmentShopifyService appointmentShopifyService, IUserService userService)
        {
            _appointmentShopifyService = appointmentShopifyService;
            _userService = userService;
        }

        public async Task SaveOrdertoLocation(long orderId, int locationId)
        {
            var order = await _appointmentShopifyService.GetOrder(orderId);

            if (order == null)
            {
                throw new Exception("order cannot accessed with id: " + orderId);
            }
            
            decimal price = -1;
            try
            {
                price = Convert.ToDecimal(order.Order.CurrentSubtotalPrice);
            }
            catch (Exception e)
            {
                throw new Exception("price cannot be converted for order id: " + order.Order.Id);
            }
            var checkOrder = Get(o => o.OrderId == order.Order.Id);
            if (checkOrder != null)
            {
                checkOrder.LocationId = locationId;
                base.Update(checkOrder);
            }
            else
            {
                var lineItemsString = JsonConvert.SerializeObject(order.Order.LineItems);
                var orderJson = JsonConvert.SerializeObject(order);

                var locationOrder = new TblOrder
                {
                    OrderId = order.Order.Id,
                    LocationId = locationId,
                    CustomerName = order.Order.Customer.FirstName,
                    ContactEmail = order.Order.ContactEmail,
                    CustomerLastname = order.Order.Customer.LastName,
                    Price = price,
                    LineItems = lineItemsString,
                    AssignedDate = DateTime.Now,
                    ContactTelno = string.IsNullOrEmpty(order.Order.BillingAddress.Phone) ? "-" : order.Order.BillingAddress.Phone,
                    WorkshopDate = getWorkshopDateTime(order.Order.LineItems,order.Order.Id),
                    WorkshoLocation = getWorkshopLocation(order.Order.LineItems),
                    OrderJson = orderJson
                };

                try
                {
                    base.Add(locationOrder);
                }
                catch (Exception e)
                {
                    throw new Exception("Unexpected error to save location with " + orderId + " and location id: " + locationId);
                }
               
            }
        }

        public List<Notification> OrderNotifications()
        {
            var user = _userService.GetLoggedUser();
            var orders = GetList(o => o.LocationId == user.LocationId, o => o.Location);
            List<Notification> notifications = new List<Notification>();
            foreach (var order in orders)
            {
                notifications.Add(new Notification()
                {
                    Date = order.WorkshopDate.HasValue ? order.WorkshopDate.Value.ToString("dd/MM/yyyy") : "No date specified",
                    Description = $"a new workshop assigned to your location {order.Location.LocationName} {order.WorkshoLocation}",
                    Icon = "hurry.png",
                    NotificationId = order.AssignedDate.ToBinary() + "order" + user.Id
                });
            }

            return notifications;
        }

        public string getWorkshopLocation(List<LineItem> lineItems)
        {
            if (lineItems.Count > 0)
            {
                var lineItem = lineItems[0];
                var workshopDateString = lineItem.Properties.Where(p => p.Name.Equals("Location"));
                try
                {
                    return workshopDateString.ToList()[0].Value;
                }
                catch (Exception e)
                {
                    // TODO: just log
                }
            }

            return "-";
        }

        public DateTime? getWorkshopDateTime(List<LineItem> lineItems, long orderId)
        {
            if (lineItems.Count > 0)
            {
                var lineItem = lineItems[0];
                var workshopDateString = lineItem.Properties.Where(p => p.Name.Equals("Date")).ToList();
                var workshopTimeString = lineItem.Properties.Where(p => p.Name.Equals("Time")).ToList();
                try
                {
                    if (workshopDateString.Any() && !string.IsNullOrEmpty(workshopDateString[0].Value))
                    {
                        string dateObject = workshopDateString.ToList()[0].Value;
                        if (workshopTimeString.Any() && !string.IsNullOrEmpty(workshopTimeString[0].Value))
                        {
                            dateObject += " " + workshopTimeString.ToList()[0].Value;
                            DateTime date = DateTime.ParseExact(dateObject, "dd/MM/yyyy hh:mmtt", CultureInfo.InvariantCulture);
                            return date;
                        }
                        else
                        {
                            DateTime date = DateTime.ParseExact(dateObject, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            return date;

                        }
                    }

                    return null;
                }
                catch (Exception e)
                {
                    return null;
                }
            }

            return null;
        }
    }
}