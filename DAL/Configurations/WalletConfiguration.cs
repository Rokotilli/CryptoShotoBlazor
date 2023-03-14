using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets")
                .HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(w => w.UserId)
                .IsRequired();

            builder.Property(w => w.CoinId)
                .IsRequired();

            builder.Property(w => w.Count)
                .IsRequired()
                .HasMaxLength(200000);

            builder.HasCheckConstraint("Count", "Count > 0");
            builder.HasIndex(w => w.Id).IsUnique();
            builder.HasIndex(w => new { w.UserId, w.CoinId }).IsUnique();

            builder.HasData(
                new Wallet { Id = 1, UserId = 1, CoinId = 1, Count = 1 },
                new Wallet { Id = 2, UserId = 2, CoinId = 2, Count = 1 },
                new Wallet { Id = 3, UserId = 3, CoinId = 3, Count = 1 }
            );
        }
    }
}
