using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MKT.DataAccess.Model.AppointmentDB
{
    public partial class AppointmentContext : DbContext
    {
        public AppointmentContext()
        {
        }

        public AppointmentContext(DbContextOptions<AppointmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAnnouncement> TblAnnouncements { get; set; }
        public virtual DbSet<TblLocation> TblLocations { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblTicket> TblTickets { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:mkt-appointment.database.windows.net,1433;Initial Catalog=Appointment;Persist Security Info=False;User ID=mktbilgiislem;Password=Melisakoray1923;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CS_AI");

            modelBuilder.Entity<TblAnnouncement>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<TblLocation>(entity =>
            {
                entity.Property(e => e.LocationName).IsUnicode(false);
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.Property(e => e.ContactEmail).IsUnicode(false);

                entity.Property(e => e.ContactTelno).IsUnicode(false);

                entity.Property(e => e.CustomerLastname).IsUnicode(false);

                entity.Property(e => e.CustomerName).IsUnicode(false);

                entity.Property(e => e.LineItems).IsUnicode(false);

                entity.Property(e => e.OrderJson).IsUnicode(false);

                entity.Property(e => e.WorkshoLocation).IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Order_Location_Tbl_Location");
            });

            modelBuilder.Entity<TblTicket>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.TicketHistory).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.AnsweredBy)
                    .WithMany(p => p.TblTicketAnsweredBies)
                    .HasForeignKey(d => d.AnsweredById)
                    .HasConstraintName("FK_Tbl_Ticket_AnsweredBy_Tbl_User");

                entity.HasOne(d => d.TicketOwner)
                    .WithMany(p => p.TblTicketTicketOwners)
                    .HasForeignKey(d => d.TicketOwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Ticket_TicketOwnerTbl_User");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NameSurname).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Rol).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_User_Location_Tbl_Location");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
