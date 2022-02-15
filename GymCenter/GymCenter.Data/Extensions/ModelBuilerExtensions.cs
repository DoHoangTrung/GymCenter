using GymCenter.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymCenter.Data.Extensions
{
    public static class ModelBuilerExtensions
    {
        public static void Seed(this ModelBuilder modelBuiler)
        {
            var ADMIN_ID = Guid.NewGuid();
            var USER_ID = Guid.NewGuid();
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var USER_ROLE_ID = Guid.NewGuid();

            modelBuiler.Entity<AppRole>().HasData(
                new AppRole()
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"

                }, new AppRole()
                {
                    Id = USER_ROLE_ID,
                    Name = "user",
                    NormalizedName = "user",
                    Description = "User role"

                }, new AppRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "employee",
                    NormalizedName = "employee",
                    Description = "Employee role"

                });

            var hasher = new PasswordHasher<AppUser>();
            var seedUser = new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                FirstName = "Trung",
                LastName = "Do",
                Dob = new DateTime(1998, 3, 18),
            };

            seedUser.PasswordHash = hasher.HashPassword(seedUser, "Trung123$");
            modelBuiler.Entity<AppUser>().HasData(seedUser,
                new AppUser()
                {
                    Id = USER_ID,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@gmail.com",
                    NormalizedEmail = "user@gmail.com",
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty,
                    FirstName = "Trung",
                    LastName = "Do",
                    Dob = new DateTime(1998, 3, 18),
                    PasswordHash = hasher.HashPassword(null, "Trung123$")
                });

            modelBuiler.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID

                }, new IdentityUserRole<Guid>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID

                });


            //insert category
            modelBuiler.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Yoga",
                }, new Category()
                {
                    Id = 2,
                    Name = "Gym",
                });

            //insert yoga service
            modelBuiler.Entity<Service>().HasData(
                new Service()
                {
                    Id = 1,
                    Name = "Gói tập gym 1 tháng",
                    CategoryId = 2,
                    NumberDaysUse = 30,
                    Price = 300000,
                    Description = "Đang tập lăn ra ngủ",
                });

            //insert card
            modelBuiler.Entity<MembershipCard>().HasData(
                new MembershipCard()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    UserId = USER_ID,
                    Status = Enums.MemberShipCardStatus.Active,
                });

            modelBuiler.Entity<ServiceInCard>().HasData(new ServiceInCard()
            {
                Id =1 ,
                CheckinCount = 0,
                DateBegin = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(30),
                DateRegister = DateTime.Now,
                ServiceId = 1,
                CardId = 1,
            });

        }
    }
}
