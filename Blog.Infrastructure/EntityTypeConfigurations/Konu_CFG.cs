using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Domain.Enums;

namespace Blog.Infrastructure.EntityTypeConfigurations
{
    public class Konu_CFG : IEntityTypeConfiguration<Konu>
    {
        public void Configure(EntityTypeBuilder<Konu> builder)
        {
            builder.ToTable("KONULAR");

            builder.Property(x => x.KonuId).
                HasColumnName("KONU_ID").
                UseIdentityColumn(5, 1);

            builder.Property(x => x.EklemeTarih)
             .HasColumnName("EKLEME_TARIHI");

            builder.Property(x => x.SilmeTarihi)
             .HasColumnName("SILINME_TARIHI");

            builder.Property(x => x.GuncellemeTarihi)
             .HasColumnName("GUNCELLENME_TARİHİ");

            builder.Property(x => x.KayitDurumu)
             .HasColumnName("KAYIT_DURUMU");

            builder.HasData(
                new Konu { KonuId = 1, KonuAdi = "Sanat" },
                new Konu { KonuId = 2, KonuAdi = "Bilim" },
                new Konu { KonuId = 3, KonuAdi = "Felsefe" }
                );
        }
    }
}
