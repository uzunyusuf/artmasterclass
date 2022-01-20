using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentApiModel;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.DataAccess.Model.Core;

namespace MKT.Business.Abstract.AppointmentsDB
{
    public interface IOrderService: IEntityRepository<TblOrder>
    {
        Task SaveOrdertoLocation(long orderId, int locationId);

        List<Notification> OrderNotifications();

        public string getWorkshopLocation(List<LineItem> lineItems);

        public DateTime? getWorkshopDateTime(List<LineItem> lineItems, long orderId);
    }
}