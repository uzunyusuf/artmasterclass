using System;
using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;

namespace MKT.Business.Concrete.AppointmentsDB
{
    public class AnnouncementService: EfEntityRepositoryBase<TblAnnouncement, AppointmentContext>, IAnnouncementService
    {
        public override void Add(TblAnnouncement entity)
        {
            entity.Date = DateTime.Now;
            base.Add(entity);
        }
    }
}