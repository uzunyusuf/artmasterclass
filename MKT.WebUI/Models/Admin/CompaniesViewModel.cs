using MKT.DataAccess.Model.AppointmentDB;
using System.Collections.Generic;

namespace MKT.WebUI.Models.Admin
{
    public class CompaniesViewModel
    {
        public TblLocation Location { get; set; }
        public List<TblLocation> Locations { get; set; }
    }
}
