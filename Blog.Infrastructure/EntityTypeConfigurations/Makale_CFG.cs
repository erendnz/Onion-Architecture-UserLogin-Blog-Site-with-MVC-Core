using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Blog.Domain.Enums;

namespace Blog.Infrastructure.EntityTypeConfigurations
{
    public class Makale_CFG : IEntityTypeConfiguration<Makale>
    {
        public void Configure(EntityTypeBuilder<Makale> builder)
        {
            builder.ToTable("MAKALELER");

            builder.Property(x => x.MakaleId)
                .HasColumnName("MAKALE_ID");

            builder.Property(x => x.Baslik)
             .HasColumnName("BASLIK")
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(x => x.Detay)
             .HasColumnName("DETAY")
             .HasMaxLength(100000)
             .IsRequired();

            builder.Property(x => x.ResimYolu)
             .HasColumnName("RESIM_YOLU")
             .HasMaxLength(1000);

            builder.Property(x => x.GoruntulenmeSayisi)
             .HasColumnName("GORUNTULENME_SAYISI")
             .HasDefaultValue(0);

            builder.Property(x => x.EklemeTarih)
                 .HasColumnName("EKLEME_TARIHI");

            builder.Property(x => x.SilmeTarihi)
                 .HasColumnName("SILINME_TARIHI");

            builder.Property(x => x.GuncellemeTarihi)
                 .HasColumnName("GUNCELLENME_TARİHİ");

            builder.Property(x => x.KayitDurumu)
                 .HasColumnName("KAYIT_DURUMU");

            builder.Property(x => x.KonuId)
             .HasColumnName("KONU_ID");

            builder.Property(x => x.MakaleEkleyenId)
             .HasColumnName("MAKALE_EKLEYEN_ID");
        }
    }
}
