using MKT.DataAccess.Model.AppointmentApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Business.Abstract
{
    public interface IAppointmentShopifyService
    {
        Task<AppointmentApiModel> GetData();
        Task<AppointmentApiModel> GetData(int limit, DateTime min, DateTime max);

        Task<AppointmentApiModel> GetData(string url);

        Task<OrderApiModel> GetOrder(long orderId);
    }
}
