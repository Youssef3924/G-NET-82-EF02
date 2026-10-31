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
    internal class BadgeConfigurations : IEntityTypeConfiguration<Badge>
    {
        public void Configure(EntityTypeBuilder<Badge> B)
        {
            B.ToTable("Badge");

            B.HasKey(B => B.Id);
            B.Property(B => B.Id).UseIdentityColumn();

            B.ToTable(B => B.HasCheckConstraint(
                "CK_Badge_Tier_StandardOeVIP",
                "[Tier] IN ('Standard','VIP')"
                ));

            B.HasOne(A => A.Atendee)
                .WithOne(B => B.badge)
                .HasForeignKey<Badge>(B => B.AtendeeID)
                .OnDelete(DeleteBehavior.Cascade);
                ;
        }
    }


}
