using Microsoft.AspNetCore.Mvc.Rendering;
using MKT.DataAccess.Model.AppointmentDB;
using System.Collections.Generic;

namespace MKT.WebUI.Models.Admin
{
    public class UsersViewModel
    {
        public TblUser User { get; set; }
        public List<TblUser> USers { get; set; }

        public List<SelectListItem> RolesSelectList { get; set; }
        public List<SelectListItem> LocationsSelectList { get; set; }
    }
}
