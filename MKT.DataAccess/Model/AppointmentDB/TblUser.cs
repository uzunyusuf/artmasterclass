using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MKT.DataAccess.Model.AppointmentDB
{
    [Table("Tbl_User")]
    public partial class TblUser
    {
        public TblUser()
        {
            TblTicketAnsweredBies = new HashSet<TblTicket>();
            TblTicketTicketOwners = new HashSet<TblTicket>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [StringLength(150)]
        public string NameSurname { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Rol { get; set; }
        [Column("LocationID")]
        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty(nameof(TblLocation.TblUsers))]
        public virtual TblLocation Location { get; set; }
        [InverseProperty(nameof(TblTicket.AnsweredBy))]
        public virtual ICollection<TblTicket> TblTicketAnsweredBies { get; set; }
        [InverseProperty(nameof(TblTicket.TicketOwner))]
        public virtual ICollection<TblTicket> TblTicketTicketOwners { get; set; }
    }
}
