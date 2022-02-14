using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;


namespace GymCenter.Data.Entity
{
    public class ServiceInCardConfiguration : IEntityTypeConfiguration<ServiceInCard>
    {
        public void Configure(EntityTypeBuilder<ServiceInCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DateRegister).IsRequired();
            builder.Property(x => x.DateBegin).IsRequired();
            builder.Property(x => x.DateEnd).IsRequired();

            builder.HasOne(x => x.MembershipCard).WithMany(x => x.ServiceInCards).HasForeignKey(x => x.CardId);
            builder.HasOne(x => x.GymService).WithMany(x => x.ServiceInCards).HasForeignKey(x => x.ServiceId);
        }
    }
}
