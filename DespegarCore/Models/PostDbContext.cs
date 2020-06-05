using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DespegarCore.Models;

namespace DespegarCore.Models
{
    /*
    public partial class PostDbContext : DbContext
    {
        public PostDbContext()
        {
        }

        public PostDbContext(DbContextOptions<PostDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reserva> Reserva { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=Despegar;Uid=root;Pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("reserva");

                entity.Property(e => e.ID).HasColumnName("iD");

                entity.Property(e => e.Aerolineas).HasColumnType("varchar(50)");

                entity.Property(e => e.Clase).HasColumnType("varchar(50)");

                entity.Property(e => e.Destino).HasColumnType("varchar(50)");

                entity.Property(e => e.FechaSalida).HasColumnType("timestamp");

                entity.Property(e => e.Ida).HasColumnType("varchar(2)");

                entity.Property(e => e.Origen).HasColumnType("varchar(50)");

                entity.Property(e => e.Pasajero).HasColumnType("varchar(50)");
              

                entity.Property(e => e.SoloIda).HasColumnType("varchar(2)");
            });
        }

        public DbSet<DespegarCore.Models.Vuelos> Vuelos { get; set; }
    }*/
}
