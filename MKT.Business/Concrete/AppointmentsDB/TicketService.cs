using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.DataAccess.Constants;
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

        public void AddAnswer(int ticketId, string answer)
        {
            var user = _userService.GetLoggedUser();
            var ticket = Get(t => t.Id == ticketId, t => t.AnsweredBy, t => t.TicketOwner);

            List<TblTicket> ticketHistory = new List<TblTicket>();
            if (!string.IsNullOrEmpty(ticket.TicketHistory))
            {
                ticketHistory = JsonSerializer.Deserialize<List<TblTicket>>(ticket.TicketHistory);
                if (ticketHistory == null)
                {
                    ticketHistory = new List<TblTicket>();
                }
            }

            ticket.TicketOwner.TblTicketAnsweredBies = null;
            ticket.TicketOwner.TblTicketTicketOwners = null;
            if (ticket.AnsweredBy != null)
            {
                ticket.AnsweredBy.TblTicketAnsweredBies = null;
                ticket.AnsweredBy.TblTicketTicketOwners = null;
            }
            user.TblTicketAnsweredBies = null;
            user.TblTicketTicketOwners= null;
            
            ticketHistory.Add(ticket);
            var ticketSerialized = JsonSerializer.Serialize(ticketHistory);
            ticket.TicketHistory = ticketSerialized;
            ticket.Description = answer;
            ticket.AnsweredById = user.Id;
            ticket.AnsweredBy = user;
            if (user.Rol.Equals(ROLE.ADMIN) || user.Rol.Equals(ROLE.MODERATOR))
            {
                ticket.Closed = true;
            }
            else
            {
                ticket.Closed = false;
            }
            base.Update(ticket);
        }
    }
}