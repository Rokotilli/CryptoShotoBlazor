using DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News")
                .HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(w => w.Text);


            builder.Property(w => w.Media)
                .HasMaxLength(100);


            builder.HasIndex(w => w.Id).IsUnique();

            builder.HasData(
                new News { Id = 1, Text = "ghbrfvdncjkmfenhvdjcmkjifnhgvfdcjmkievjgnbhfjndckmjdjfvngb", Media = "dcw"},
                new News { Id = 2, Text = "bgrvfevegrbh", Media = "dcw" },
                new News { Id = 3, Text = "BTC 60000!", Media = "BabaVanga" }
            );
        }
    }
}
