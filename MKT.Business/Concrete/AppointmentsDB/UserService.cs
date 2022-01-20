using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.Core.Helper;
using MKT.DataAccess.Model.AppointmentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MKT.Business.Concrete.AppointmentsDB
{
    public class UserService: EfEntityRepositoryBase<TblUser, AppointmentContext>, IUserService
    {
        private readonly IHttpContextAccessor _context;

        public UserService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public override void Add(TblUser user)
        {
            if(string.IsNullOrEmpty(user.UserName))
            {
                throw new Exception("username cannot be empty");
            }
            if(string.IsNullOrEmpty(user.NameSurname))
            {
                throw new Exception("user name and surname cannot be empty");
            }
            if(string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("user email cannot be empty");
            }
            if(user.LocationId == 0)
            {
                throw new Exception("Please choose a location");
            }
            if(string.IsNullOrEmpty(user.Rol))
            {
                throw new Exception("Please choose a role");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new Exception("Please type password");
            }
            user.Password = Hasher.EncryptSHA1(user.Password);
            base.Add(user);
        }

        public TblUser GetLoggedUser()
        {
            if (_context.HttpContext.User.Identity == null) return null;
            var userName = _context.HttpContext.User.Identity.Name;
            return Get(u => u.UserName.Equals(userName), u=>u.Location);

        }
    }
}
