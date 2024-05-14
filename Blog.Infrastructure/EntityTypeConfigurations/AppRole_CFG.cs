using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.EntityTypeConfigurations
{
    public class AppRole_CFG : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("APP_ROLE");

            builder.Property(x => x.Id).UseIdentityColumn(3, 1);

            builder.HasData(new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.HasData(new AppRole { Id = 2, Name = "Uye", NormalizedName = "UYE", ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
