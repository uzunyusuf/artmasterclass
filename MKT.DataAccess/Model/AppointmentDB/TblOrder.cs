using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MKT.DataAccess.Model.AppointmentDB
{
    [Table("Tbl_Order")]
    public partial class TblOrder
    {
        [Key]
        public int Id { get; set; }
        public long OrderId { get; set; }
        [Required]
        [Column("contactEmail")]
        [StringLength(100)]
        public string ContactEmail { get; set; }
        [Required]
        [Column("contactTelno")]
        [StringLength(20)]
        public string ContactTelno { get; set; }
        [Required]
        [Column("customerName")]
        [StringLength(50)]
        public string CustomerName { get; set; }
        [Required]
        [Column("customerLastname")]
        [StringLength(50)]
        public string CustomerLastname { get; set; }
        [Column("LocationID")]
        public int LocationId { get; set; }
        [Column("price", TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WorkshopDate { get; set; }
        [Required]
        [StringLength(4096)]
        public string LineItems { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AssignedDate { get; set; }
        [Required]
        [StringLength(250)]
        public string WorkshoLocation { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty(nameof(TblLocation.TblOrders))]
        public virtual TblLocation Location { get; set; }
    }
}
