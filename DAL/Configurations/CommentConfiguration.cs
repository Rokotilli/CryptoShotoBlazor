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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments")
                .HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(u => u.PostId)
                .IsRequired();

            builder.Property(u => u.UserId)
                .IsRequired();

            builder.Property(u => u.Text)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(u => u.Post)
                .WithMany()
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(u => u.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(u => u.Id).IsUnique();
        }
    }
}
