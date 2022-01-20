using System.Collections.Generic;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.WebUI.Models.Announcement
{
    public class AnnouncementListViewModel
    {
        public List<TblAnnouncement> AnnouncementList { get; set; }
    }
}