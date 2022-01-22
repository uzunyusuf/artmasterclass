using System.Collections;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using MKT.DataAccess.Model.AppointmentDB;
using Newtonsoft.Json;

namespace MKT.WebUI.Filter
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string[] _roles;

        private readonly ILogger<AuthorizeActionFilter> _logger;

        public AuthorizeActionFilter(string[] roles, ILogger<AuthorizeActionFilter> logger)
        {
            _logger = logger;
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var actorString = context.HttpContext.User.FindFirstValue(ClaimTypes.Actor);
            if (string.IsNullOrEmpty(actorString))
            {
                _logger.LogError("AuthorizeActionFilter filter actor adı boş geldi");
                context.Result = new RedirectResult("/Security/Login");
                return;
            }
            var user = JsonConvert.DeserializeObject<TblUser>(actorString);

            if (user == null || !((IList)_roles).Contains(user.Rol))
            {
                context.Result = new RedirectResult("/Security/AccessDenied");
            }
        }

    }

}