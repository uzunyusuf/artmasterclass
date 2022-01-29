using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.Business.Abstract.AppointmentsDB
{
    public interface ITicketService: IEntityRepository<TblTicket>
    {
        void AddAnswer(int ticketId, string answer);
    }
}