using System;
using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.WebUI.Models.Announcement;

namespace MKT.WebUI.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult CreateAnnouncement()
        {
            var model = new CreateAnnouncementViewModel()
            {
                Announcement = new TblAnnouncement(),
                LastAnnouncementsList = _announcementService.GetList(a => a.Date > DateTime.Today.AddDays(-10))
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateAnnouncement(CreateAnnouncementViewModel model)
        {
            try
            {
                _announcementService.Add(model.Announcement);
                return new JsonResult(new { Message = "Announcement is saved successfully!" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });
            }
        }

        public IActionResult AnnouncementList()
        {
            var model = new AnnouncementListViewModel()
            {
                AnnouncementList = _announcementService.GetList(a => a.Date > DateTime.Today.AddDays(-15))
            };
            return View(model);
        }
    }
}
