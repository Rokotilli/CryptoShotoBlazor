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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles")
                .HasKey(w => w.Id);

            builder.Property(w => w.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(w => w.Id)
                .IsRequired();

            builder.HasIndex(w => w.Id).IsUnique();
            builder.HasIndex(с => с.Name).IsUnique();

            builder.HasData(
                new Role { Id = 1, Name="User"},
                new Role { Id = 2, Name ="Admin"}
            );
        }
    }
}
