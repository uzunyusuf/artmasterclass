using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MKT.DataAccess.Model.AppointmentApiModel;

namespace MKT.WebUI.Models.Appointment
{
    public class AppointmentDashboardViewModel
    {
        public AppointmentApiModel Appointment { get; set; }
        public string Url { get; set; }
        public string DateBetween { get; set; }
        public int Limit { get; set; }

        public List<SelectListItem> LocationSelectList { get; set; }
        public SaveOrderLocationModel SaveOrderLocationModel { get; set; }
    }
}
