
using DespegarCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DespegarCore.Data
{
    public class DespegarContext : DbContext
    {
        public DespegarContext(DbContextOptions<DespegarContext> options) : base(options)
        {
        }
            public DbSet<Reserva> Reserva { get; set; }
           public DbSet<Vuelos> Vuelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>().ToTable("Reserva");        
            modelBuilder.Entity<Vuelos>().ToTable("Vuelos");

        }

       

    }

}


    


