using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MKT.DataAccess.Model.AppointmentDB
{
    [Table("Tbl_Ticket")]
    public partial class TblTicket
    {
        [Key]
        public int Id { get; set; }
        [Column("TicketOwnerID")]
        public int TicketOwnerId { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        [StringLength(4096)]
        public string Description { get; set; }
        public string TicketHistory { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTime { get; set; }
        public bool Closed { get; set; }
        [Column("AnsweredByID")]
        public int? AnsweredById { get; set; }

        [ForeignKey(nameof(AnsweredById))]
        [InverseProperty(nameof(TblUser.TblTicketAnsweredBies))]
        public virtual TblUser AnsweredBy { get; set; }
        [ForeignKey(nameof(TicketOwnerId))]
        [InverseProperty(nameof(TblUser.TblTicketTicketOwners))]
        public virtual TblUser TicketOwner { get; set; }
    }
}
