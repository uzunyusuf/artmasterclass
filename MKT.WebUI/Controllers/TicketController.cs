using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Constants;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.WebUI.Models;
using MKT.WebUI.Models.Ticket;

namespace MKT.WebUI.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IUserService _userService;

        public TicketController(ITicketService ticketService, IUserService userService)
        {
            _ticketService = ticketService;
            _userService = userService;
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
            var user = _userService.GetLoggedUser();
            List<TblTicket> ticketList = null;
            if (user.Rol.Equals(ROLE.USER))
            {
                ticketList = _ticketService.GetList(t => t.TicketOwnerId == user.Id, t => t.TicketOwner);
            }
            else
            {
                ticketList = _ticketService.GetList(t => !t.Closed, t => t.TicketOwner);
            }
            var model = new TicketsViewModel()
            {
                Tickets = ticketList
            };
            return View(model);
        }

        public IActionResult TicketDetails(int ticketId)
        {
            var ticket = _ticketService.Get(t => t.Id == ticketId, t=> t.TicketOwner);
            if (ticket == null)
            {
                return RedirectToAction("Error", "Home",
                    new ErrorViewModel() { Message = "ticket cannot found with id: " + ticketId });
            }

            var model = new TicketDetailsViewModel()
            {
                Ticket = ticket,
                TicketHistory = string.IsNullOrEmpty(ticket.TicketHistory) ? new List<TblTicket>():  JsonSerializer.Deserialize<List<TblTicket>>(ticket.TicketHistory)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PostTicketAnswer(TicketDetailsViewModel model)
        {
            try
            {
                _ticketService.AddAnswer(model.Ticket.Id, model.AddDescription);
                return new JsonResult(new { Message = "Your answer is saved successfully" });
            }
            catch (Exception e)
            {

                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });
            }
        }
    }
}
