using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<SiteUser> Users { get; set; }
        public DbSet<Allas> Allasok { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Allas>()
                        .HasMany<SiteUser>(s => s.Jelentkezok)
                        .WithMany(c => c.Allasok);
            base.OnModelCreating(modelBuilder);

        }
    }
}
