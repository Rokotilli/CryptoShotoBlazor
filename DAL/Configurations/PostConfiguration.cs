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
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts")
                .HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(w => w.Text)
                .HasMaxLength(100);

            builder.Property(w => w.Photo)
                .HasMaxLength(100);

            builder.Property(w => w.Date)
                .IsRequired();

            builder.Property(w => w.UserId)
                .IsRequired();

            builder.HasIndex(w => w.Id).IsUnique();

            builder.HasData(
                new Post { Id = 1, UserId=1, Text="Hahahhahahaha ahkhvfbdcjsnknfdvgbhvjdn", Photo="", Date=DateTime.Now },
                new Post { Id = 2, UserId = 2, Text = "brgfvdcvgrhbt ahkhvfbdcjsnknfdvgbhvjdn", Photo = "", Date = DateTime.Now },
                new Post { Id = 3, UserId = 3, Text = "refrwreftg rsvfead", Photo = "", Date = DateTime.Now }
            );
        }
    }
}
