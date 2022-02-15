using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Entity
{
    public class CheckInHistoryConfiguration: IEntityTypeConfiguration<CheckInHistory>
    {
        public void Configure(EntityTypeBuilder<CheckInHistory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Date).IsRequired();

            builder.HasOne(x => x.ServiceInCard).WithMany(x => x.CheckInHistories).HasForeignKey(x => x.ServiceInCardId);

        }
    }
}
