using G_NET_82_EF02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Configurations
{
    internal class EventConfigurations : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> E)
        {
            E.ToTable("Events");

            E.HasKey(e => e.Id);
            E.Property(e => e.Id).UseIdentityColumn(1, 1);

            E.Property(e=>e.Desription)
                .HasColumnType("varchar")
                .HasMaxLength(200);

            E.Property(e => e.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            E.HasOne(o => o.organizer)
                .WithMany(E => E.Events)
                .HasForeignKey(E => E.OrganizerID)
                .OnDelete(DeleteBehavior.Restrict);
                ;


        }
    }
}
