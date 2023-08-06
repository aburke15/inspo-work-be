using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InspoWork.Data;

public class IrohDbContext : DbContext
{
    public IrohDbContext(DbContextOptions<IrohDbContext> options)
        : base(options)
    { }

    public DbSet<Post> Posts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Post>(entityType =>
        {
            entityType.ToTable("posts");
            
            entityType.HasKey(post => post.Id);
                
            entityType.Property(post => post.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
                
            entityType.Property(post => post.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(50);

            entityType.Property(post => post.Body)
                .HasColumnName("body")
                .IsRequired();

            entityType.Property(post => post.PostType)
                .HasColumnName("post_type")
                .IsRequired();
        });
    }
}