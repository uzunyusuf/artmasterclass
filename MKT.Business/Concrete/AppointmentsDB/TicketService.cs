using System;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.Business.Concrete.AppointmentsDB
{
    public class TicketService: EfEntityRepositoryBase<TblTicket, AppointmentContext>, ITicketService
    {
        private readonly IUserService _userService;

        public TicketService(IUserService userService)
        {
            _userService = userService;
        }

        public override void Add(TblTicket ticket)
        {
            var user = _userService.GetLoggedUser();
            if (string.IsNullOrEmpty(ticket.Title))
            {
                throw new Exception("Ticket title cannot be null");
            }
            ticket.Title = ticket.Title.Trim();

            if (string.IsNullOrEmpty(ticket.Description))
            {
                throw new Exception("Ticket description cannot be null");
            }
            ticket.Description = ticket.Description.Trim();

            ticket.TicketOwnerId = user.Id;
            ticket.Closed = false;
            ticket.CreatedTime = DateTime.Now;

            base.Add(ticket);
        }
    }
}