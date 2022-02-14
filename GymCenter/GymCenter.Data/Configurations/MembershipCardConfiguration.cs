using GymCenter.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class MembershipCardConfiguration : IEntityTypeConfiguration<MembershipCard>
    {
        public void Configure(EntityTypeBuilder<MembershipCard> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.DateCreated).IsRequired();
            builder.Property(x => x.DateUpdated).IsRequired();
            builder.Property(x => x.Status).IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.MembershipCards).HasForeignKey(x => x.UserId);
        }
    }

}
