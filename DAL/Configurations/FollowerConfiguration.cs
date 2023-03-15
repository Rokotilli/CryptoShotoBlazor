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
    internal class FollowerConfiguration : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {
            builder.ToTable("Followers")
                .HasKey(f => f.Id);

            builder.Property(l => l.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);

            builder.Property(f => f.FollowerId)
                .IsRequired();

            builder.Property(f => f.IdleId)
                .IsRequired();

            builder.HasOne(f => f.follower)
                .WithMany()
                .HasForeignKey(f => f.FollowerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.idle)
                .WithMany()
                .HasForeignKey(f => f.IdleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(l => l.Id).IsUnique();
            builder.HasIndex(l => new { l.FollowerId, l.IdleId }).IsUnique();
        }
    }
}
