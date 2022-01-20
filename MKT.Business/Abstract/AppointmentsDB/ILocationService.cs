using MKT.Core.DataAccess;
using MKT.DataAccess.Model.AppointmentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Business.Abstract.AppointmentsDB
{
    public interface ILocationService: IEntityRepository<TblLocation>
    {
    }
}
