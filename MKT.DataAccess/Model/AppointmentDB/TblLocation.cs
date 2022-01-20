using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MKT.DataAccess.Model.AppointmentDB
{
    [Table("Tbl_Location")]
    public partial class TblLocation
    {
        public TblLocation()
        {
            TblOrders = new HashSet<TblOrder>();
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string LocationName { get; set; }

        [InverseProperty(nameof(TblOrder.Location))]
        public virtual ICollection<TblOrder> TblOrders { get; set; }
        [InverseProperty(nameof(TblUser.Location))]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
