using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.WebUI.Models.Admin;
using MKT.WebUI.Tools;
using System;
using MKT.Core.Helper;
using MKT.DataAccess.Constants;
using MKT.WebUI.Filter;
using MKT.WebUI.Models;

namespace MKT.WebUI.Controllers
{
    [Authorize(new []{ROLE.ADMIN, ROLE.MODERATOR})]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILocationService _locationService;

        public AdminController(IUserService userService, ILocationService companyService)
        {
            _userService = userService;
            _locationService = companyService;
        }

        public IActionResult Users(int? id)
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

        public IActionResult UpdateUser(int? id)
        {
            TblUser user = null;
            if (id.HasValue && id.Value != 0)
            {
                user = _userService.Get(u => u.Id == id.Value);
            }

            if (user == null)
            {
                return RedirectToAction("Error", "Home",
                    new ErrorViewModel() { Message = "User cannot found with id: " + (id.HasValue ? id.Value : "") });
            }

            var model = new UpdateUserViewModel()
            {
                User = user,
                RolesSelectList = SelectConverter.RoleParameters(),
                LocationsSelectList = SelectConverter.CreateSelectList(_locationService.GetList(), c => c.Id, c => c.LocationName)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateUser(UpdateUserViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.NewPassword))
                {
                    model.User.Password = Hasher.EncryptSHA1(model.NewPassword);
                }
                _userService.Update(model.User);
                return new JsonResult(new { Message = "User updated successfully" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });
            }
        }

        public IActionResult UserPassive(int userId)
        {
            var user = _userService.Get(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("Error", "Home",
                    new ErrorViewModel() { Message = "User cannot found"});
            }

            user.IsDeleted = !user.IsDeleted;
            try
            {
                _userService.Update(user);
                return RedirectToAction("Users");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home",
                    new ErrorViewModel() { Message = "User cannot updated: " + e.Message });
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
                return new JsonResult(new { Message = "Location added successfully" });
            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });
            }
        }

        public IActionResult UpdateLocation(int id)
        {
            var location = _locationService.Get(l => l.Id == id);
            if (location == null)
            {
                return RedirectToAction("Error", "Home",
                    new ErrorViewModel() { Message = "location cannot found" });

            }
            var model = new UpdateLocationViewModel()
            {
                Location = location
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateLocation(UpdateLocationViewModel model)
        {
            try
            {
                _locationService.Update(model.Location);
                return RedirectToAction("Locations");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home",
                    new ErrorViewModel() { Message = "Location cannot updated: " + e.Message });
            }
        }

    }
}
