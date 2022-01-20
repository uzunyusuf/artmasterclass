using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.Business.Abstract.AppointmentsDB
{
    public interface IOrderSingletonService: IEntityRepository<TblOrder>
    {
        
    }
}