using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.EntityTypeConfigurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("APP_USER");

            builder.Property(x => x.Id).
                HasColumnName("ID").
                UseIdentityColumn(2, 1);

            builder.Property(x => x.Ad).
                HasColumnName("AD");

            builder.Property(x => x.Soyad).
                HasColumnName("SOYAD");

            var superUser = new AppUser 
            { 
                Id = 1,
                Ad = "Cevdet", 
                Soyad = "Korkmaz", 
                Email = "cevdet@deneme.com", 
                UserName = "Cevdo", 
                NormalizedEmail = "CEVDET@DENEME.COM",
                NormalizedUserName = "CEVDO", 
                SecurityStamp = Guid.NewGuid().ToString(), 
                TwoFactorEnabled = false, 
                ConcurrencyStamp = Guid.NewGuid().ToString(), 
                EmailConfirmed = false 
            };

            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            superUser.PasswordHash = hasher.HashPassword(superUser, "Cevdo_123");


            builder.HasData(superUser);
        }
    }
}
