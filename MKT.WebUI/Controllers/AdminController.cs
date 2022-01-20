using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.WebUI.Models.Admin;
using MKT.WebUI.Tools;
using System;

namespace MKT.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILocationService _locationService;

        public AdminController(IUserService userService, ILocationService companyService)
        {
            _userService = userService;
            _locationService = companyService;
        }

        public IActionResult Users()
        {
            var companiesList = _locationService.GetList();
            var model = new UsersViewModel()
            {
                User = new TblUser(),
                USers = _userService.GetList(null, u => u.Location),
                RolesSelectList = SelectConverter.RoleParameters(),
                LocationsSelectList = SelectConverter.CreateSelectList(companiesList,c => c.Id,c => c.LocationName)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Users(UsersViewModel model)
        {
            try
            {
                _userService.Add(model.User);
                return new JsonResult(new { Message = "User added successfully" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new {Message = e.Message});
            }
        }

        public IActionResult Locations()
        {
            var model = new CompaniesViewModel()
            {
                Location = new TblLocation(),
                Locations = _locationService.GetList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Locations(CompaniesViewModel model)
        {
            try
            {
                _locationService.Add(model.Location);
                return new JsonResult(new { Message = "Company added successfully" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });
            }
        }

    }
}
