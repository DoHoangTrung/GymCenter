﻿using GymCenter.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Dob).IsRequired();

            builder.Property(x => x.Email).IsRequired();
        }
    }
}
