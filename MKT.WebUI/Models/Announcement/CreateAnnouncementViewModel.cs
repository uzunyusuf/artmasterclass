using System.Collections.Generic;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.WebUI.Models.Announcement
{
    public class CreateAnnouncementViewModel
    {
        public TblAnnouncement Announcement { get; set; }
        public List<TblAnnouncement> LastAnnouncementsList { get; set; }
    }
}