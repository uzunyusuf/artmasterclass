using System.Collections.Generic;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.WebUI.Models.Ticket
{
    public class TicketDetailsViewModel
    {
        public TblTicket Ticket { get; set; }
        public List<TblTicket> TicketHistory { get; set; }

        public string AddDescription { get; set; }
    }
}