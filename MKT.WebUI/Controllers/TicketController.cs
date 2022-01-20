using System;
using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.WebUI.Models.Ticket;

namespace MKT.WebUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult CreateTicket()
        {
            var model = new CreateTicketViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateTicket(CreateTicketViewModel model)
        {
            try
            {
                _ticketService.Add(model.NewTicket);
                return new JsonResult(new { Message = "Ticket created successfully" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });
            }
        }

        public IActionResult Tickets()
        {
            var model = new TicketsViewModel()
            {
                Tickets = _ticketService.GetList(t => !t.Closed, t => t.TicketOwner)
            };
            return View(model);
        }
    }
}
