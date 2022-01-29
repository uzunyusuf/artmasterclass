using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MKT.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.DataAccess.Constants;
using MKT.DataAccess.Model.Core;
using MKT.WebUI.Models.Home;

namespace MKT.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService, ILocationService locationService, IUserService userService)
        {
            _logger = logger;
            _orderService = orderService;
            _locationService = locationService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var orderList = _orderService.GetList();
            var locationList = _locationService.GetList();
            if (User.IsInRole(ROLE.USER))
            {
                var user = _userService.GetLoggedUser();
                orderList = orderList.FindAll(o => o.LocationId == user.LocationId);
            }
            var model = new HomeIndexViewModel()
            {
                TotalAssignedWorkshop = orderList.Count,
                TotalLocation = locationList.Count,
                FutureWorkshopCount = orderList.Count(o => o.WorkshopDate > DateTime.Now),
                AssignedWorkshopPriceTotal = (double)orderList.Sum(o => o.Price)
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult PriceTotalByLocation()
        {
            var orderList = _orderService.GetList(null, o => o.Location);
            if (User.IsInRole(ROLE.USER))
            {
                var user = _userService.GetLoggedUser();
                orderList = orderList.FindAll(o => o.LocationId == user.LocationId);
            }
            var jsonResult = orderList.GroupBy(o => o.Location.LocationName).Select(
                group => new {label = @group.Key, value = @group.ToList().Sum(p => p.Price )});
            return new JsonResult(jsonResult);
        }

        public JsonResult TotalOrderByLocation()
        {
            var orderList = _orderService.GetList(null, o => o.Location);
            if (User.IsInRole(ROLE.USER))
            {
                var user = _userService.GetLoggedUser();
                orderList = orderList.FindAll(o => o.LocationId == user.LocationId);
            }
            var jsonResult = orderList.GroupBy(o => o.Location.LocationName).Select(
                group => new {label = @group.Key, value = @group.Count()});
            return new JsonResult(jsonResult);
        }

        public IActionResult DailyTotalEarning()
        {
            var orderList = _orderService.GetList(o => o.WorkshopDate.HasValue);
            if (User.IsInRole(ROLE.USER))
            {
                var user = _userService.GetLoggedUser();
                orderList = orderList.FindAll(o => o.LocationId == user.LocationId);
            }
            var jsonResult = orderList.GroupBy(o => o.WorkshopDate.Value.Date).Select(
                group => new { label = @group.Key.ToString("dd/MM/yyyy"), value = @group.Sum(g => g.Price) });
            return new JsonResult(jsonResult);
        }

        public IActionResult Notifications()
        {
            List<Notification> notifications = new List<Notification>();
            notifications.AddRange(_orderService.OrderNotifications());
            var model = new NotificationsViewModel()
            {
                Notifications = notifications
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationsAsync()
        {
            List<Notification> notifications = new List<Notification>();
            notifications.AddRange(_orderService.OrderNotifications());
            return new JsonResult(notifications);
        }

    }
}
