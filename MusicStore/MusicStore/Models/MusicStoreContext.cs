using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MusicStore.Models
{
    public partial class MusicStoreContext : DbContext
    {
        public MusicStoreContext()
        {
        }

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=167.71.46.107; database=MusicStore; user=admin; Pwd=GreenMood2020!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Availability)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.Doze).HasColumnType("varchar(150)");

                entity.Property(e => e.Finisaj).HasColumnType("varchar(45)");

                entity.Property(e => e.Forma).HasColumnType("varchar(45)");

                entity.Property(e => e.Material).HasColumnType("varchar(45)");

                entity.Property(e => e.Model).HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NumarTaste).HasColumnType("int(11)");

                entity.Property(e => e.Photo).HasColumnType("varchar(200)");

                entity.Property(e => e.ReviewNumber)
                    .HasColumnName("Review Number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Serie).HasColumnType("varchar(45)");

                entity.Property(e => e.Stars).HasColumnType("int(11)");

                entity.Property(e => e.Type).HasColumnType("int(11)");
            });
        }
    }
}
