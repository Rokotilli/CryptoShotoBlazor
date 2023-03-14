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
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.ToTable("Coins")
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.Price)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(с => с.Id).IsUnique();
            builder.HasIndex(с => с.Name).IsUnique();

            builder.HasData(
                new Coin { Id = 1, Name = "BNB", Price = 200 },
                new Coin { Id = 2, Name = "BTC", Price = 60000 },
                new Coin { Id = 3, Name = "SCP", Price = 500 }
            );
        }
    }
}
