using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YikyakDataLibrary.Models;

namespace YikyakDataLibrary.DataAccess
{
    public class PostsContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public PostsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().Property(p => p.PostId).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Post>().Property(p => p.Body).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Post>().ToTable("Posts");

            modelBuilder.Entity<Comment>().Property(c => c.CommentId).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>().Property(c => c.Body).IsRequired().HasMaxLength(300);
            modelBuilder.Entity<Comment>().ToTable("Comments");

            modelBuilder.Entity<Comment>()
                        .HasOne(c => c.Post)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(c => c.PostId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Comment_Post")
                        .IsRequired();
        }
    }
}
