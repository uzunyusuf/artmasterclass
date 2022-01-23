using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract;
using MKT.WebUI.Models.Appointment;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Constants;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.WebUI.Tools;

namespace MKT.WebUI.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentShopifyService _appointmentShopifyService;
        private readonly ILocationService _locationService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public AppointmentController(IAppointmentShopifyService appointmentShopifyService, ILocationService locationService, IOrderService orderService, IUserService userService)
        {
            _appointmentShopifyService = appointmentShopifyService;
            _locationService = locationService;
            _orderService = orderService;
            _userService = userService;
        }

        public async Task<IActionResult> AppointmentDashboard()
        {

            var appointments = await _appointmentShopifyService.GetData();
            var model = new AppointmentDashboardViewModel()
            {
                Appointment = appointments,
                LocationSelectList = SelectConverter.CreateSelectList(_locationService.GetList(), l=>l.Id, l=>l.LocationName)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AppointmentDashboard(AppointmentDashboardViewModel model)
        {
            var dates = model.DateBetween.Split("-");
            var dateMin = DateTime.ParseExact(dates[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
            var dateMax = DateTime.ParseExact(dates[1], "yyyy/MM/dd", CultureInfo.InvariantCulture);

            var appointments = await _appointmentShopifyService.GetData(model.Limit, dateMin,dateMax);
            model = new AppointmentDashboardViewModel()
            {
                Appointment = appointments,
                DateBetween = model.DateBetween,
                Limit = model.Limit,
                LocationSelectList = SelectConverter.CreateSelectList(_locationService.GetList(), l => l.Id, l => l.LocationName)
            };
            return View(model);
        }

        public async Task<IActionResult> AppointmentByUrl(AppointmentDashboardViewModel model)
        {
            var appointment = await _appointmentShopifyService.GetData(model.Url);
            model.Appointment = appointment;
            model.LocationSelectList =
                SelectConverter.CreateSelectList(_locationService.GetList(), l => l.Id, l => l.LocationName);
            return View("AppointmentDashboard", model);
        }

        public IActionResult AppointmentLocationList()
        {
            List<TblOrder> orderList = null;
            if (User.IsInRole(ROLE.ADMIN) || User.IsInRole(ROLE.MODERATOR))
            {
                orderList = _orderService.GetList(null, o => o.Location);
            }
            else
            {
                var user = _userService.GetLoggedUser();
                orderList = _orderService.GetList(o => o.LocationId == user.LocationId, o => o.Location);
            }
            var model = new AppointmentLocationListViewModel()
            {
                LocationOrder = orderList
            };
            return View(model);
        }

        public async Task<IActionResult> SaveOrdertoLocation(AppointmentDashboardViewModel model)
        {
            try
            {
                await _orderService.SaveOrdertoLocation(model.SaveOrderLocationModel.OrderId,
                    model.SaveOrderLocationModel.LocationId);
                return new JsonResult(new { Message = "Workshop successfully assigned to location" });

            }
            catch (Exception e)
            {
                Response.StatusCode = 500;
                return new JsonResult(new { Message = e.Message });

            }
        }
    }
}
