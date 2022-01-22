using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.WebUI.Models.Admin
{
    public class UpdateUserViewModel
    {
        public TblUser User { get; set; }
        public List<SelectListItem> RolesSelectList { get; set; }
        public List<SelectListItem> LocationsSelectList { get; set; }
        public string NewPassword { get; set; }
    }
}