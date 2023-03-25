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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(u => u.RoleId)
                .IsRequired();

            builder.HasIndex(u => u.Id).IsUnique();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.HasData(
                new User { Id = 1, Email = "rost.daskalyuk@gmail.com", Password = "Qwerty123", UserName = "Rostik", RoleId = 1 },
                new User { Id = 2, Email = "valik.romanyuk2004@gmail.com", Password = "Qwerty123", UserName = "Valik", RoleId = 1 },
                new User { Id = 3, Email = "valentAnys@gmail.com", Password = "Qwerty123", UserName = "ValentAnys", RoleId = 1 }
            );
        }
    }
}
