using MKT.Business.Abstract.AppointmentsDB;
using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Business.Concrete.AppointmentsDB
{
    public class LocationService : EfEntityRepositoryBase<TblLocation, AppointmentContext>, ILocationService
    {
        public override void Add(TblLocation location)
        {
            if(string.IsNullOrEmpty(location.LocationName))
            {
                throw new Exception("Location name cannot be empty");
            }
            base.Add(location);
        }
    }
}
