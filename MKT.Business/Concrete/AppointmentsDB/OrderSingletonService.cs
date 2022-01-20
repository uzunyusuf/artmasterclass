using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.Business.Concrete.AppointmentsDB
{
    public class OrderSingletonService: EfEntityRepositoryBase<TblOrder, AppointmentContext>, IOrderSingletonService
    {
        
    }
}