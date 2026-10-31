using G_NET_82_EF02.Configurations;
using G_NET_82_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02
{
    internal class DbContext_Assignment:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=EFAssignment;Trusted_Connection=true;TrustServerCertificate=true");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region  OrganizerProfile
            modelBuilder.Entity<OrganizerProfile>().ToTable("OrganizerProfile");

            modelBuilder.Entity<OrganizerProfile>().HasKey(O => O.Id);
            modelBuilder.Entity<OrganizerProfile>().Property(O=>O.Id ).UseIdentityColumn(1,1);

            modelBuilder.Entity<OrganizerProfile>().Property(o => o.WebSite_Url)
                .HasColumnType("varchar")
                .HasMaxLength(500);

            modelBuilder.Entity<OrganizerProfile>().Property(o => o.Biography)
               .HasColumnType("varchar")
               .HasMaxLength(500);

            modelBuilder.Entity<OrganizerProfile>().Property(o => o.Logo_Url)
               .HasColumnType("varchar")
               .HasMaxLength(500);

            modelBuilder.Entity<OrganizerProfile>().HasOne(o => o.organizer)
                .WithOne(op => op.Profile)
                .HasForeignKey<OrganizerProfile>(op => op.OrganizerID)
                .OnDelete(DeleteBehavior.Restrict);
                

            #endregion
            modelBuilder.ApplyConfiguration<Event>(new EventConfigurations());
            modelBuilder.ApplyConfiguration<Badge>(new BadgeConfigurations());


        }
        DbSet<Atendee> Atendees { get; set; }
        DbSet<Organizer> Organizers { get; set; }


     
    }
}
