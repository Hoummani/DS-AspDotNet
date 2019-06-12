using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspDotNetCoreApp.Models;

namespace AspDotNetCoreApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //filiers
        public DbSet<Filiere> Filieres { get; set; }
        
        //etudiants
        public DbSet<Etudiant> Etudiants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Filiere>().HasMany<Etudiant>(f => f.Etudiants).WithOne(e=>e.Filiere);  
        }
    }
}
