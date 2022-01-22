using Microsoft.AspNetCore.Mvc;

namespace MKT.WebUI.Filter
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(string[] roles) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { roles }; ;
        }
    }

}