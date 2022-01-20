using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.Helper;
using MKT.DataAccess.Model.AppointmentDB;
using MKT.WebUI.Models.Security;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MKT.WebUI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IUserService _userService;

        public SecurityController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel()
            {
                User = new TblUser()
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if(string.IsNullOrEmpty(model.User.UserName) || string.IsNullOrEmpty(model.User.Password)) {
                ViewData["ErrorMessage"] = "username or password is incorrect";
                return View(model);
            }

            var loginUser = _userService.Get(u => u.UserName.Equals(model.User.UserName), u => u.Location);
            if (loginUser == null)
            {
                ViewData["ErrorMessage"] = "username or password is incorrect";
                return View(model);
            }

            if(!Hasher.CheckSha1(model.User.Password, loginUser.Password))
            {
                ViewData["ErrorMessage"] = "username or password is incorrect";
                return View(model);
            }

            // else save credentials
            await SaveCredentials(loginUser);

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        private async Task SaveCredentials(TblUser user)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Actor, JsonConvert.SerializeObject(user,new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore})));

            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.NameSurname));
            identity.AddClaim(new Claim(ClaimTypes.Dsa, user.LocationId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Dns, user.Location.LocationName));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        }
    }
}
