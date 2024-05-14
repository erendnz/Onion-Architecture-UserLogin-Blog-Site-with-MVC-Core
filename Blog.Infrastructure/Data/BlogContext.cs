using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Infrastructure.EntityTypeConfigurations;

namespace Blog.Infrastructure.Data
{
    public class BlogContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public BlogContext()
        {

        }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Konu> Konular { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseOracle("User Id = blog; Password = blog; Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SID = orcl)))");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Konfigürasyon sınıfları
            builder.ApplyConfiguration(new Makale_CFG());
            builder.ApplyConfiguration(new Konu_CFG());
            builder.ApplyConfiguration(new AppUser_CFG());
            builder.ApplyConfiguration(new AppRole_CFG());

            // Superadmin rol ekler
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });

        }

    }
}
