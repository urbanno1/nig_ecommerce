using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_Commerce_DataModel.DataModel
{
    public partial class E_CommerceDBContext : DbContext
    {
        public E_CommerceDBContext()
        {
        }

        public E_CommerceDBContext(DbContextOptions<E_CommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditTrail> AuditTrail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. 
# warning See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

                optionsBuilder.UseSqlServer("Server=DESKTOP-I5ATF7P;Database=E_CommerceDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTrail>(entity =>
            {
                entity.HasKey(e => e.AuditId);

                entity.ToTable("AuditTrail", "admin");

                entity.Property(e => e.AuditId).ValueGeneratedNever();

                entity.Property(e => e.AuditActivity).HasMaxLength(500);

                entity.Property(e => e.AuditActor).HasMaxLength(500);

                entity.Property(e => e.AudtCreatedDate).HasColumnType("datetime");
            });
        }
    }
}
