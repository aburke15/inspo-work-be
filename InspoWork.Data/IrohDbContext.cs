using System.Runtime.CompilerServices;
using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InspoWork.Data;

public class IrohDbContext : DbContext
{
    public IrohDbContext(DbContextOptions<IrohDbContext> options)
        : base(options)
    { }

    public DbSet<PostType> PostTypes { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PostType>(entityType =>
        {
            entityType.ToTable("post_types");

            entityType.HasKey(pt => pt.Id);

            entityType.Property(pt => pt.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityType.Property(pt => pt.PostTypeName)
                .HasColumnName("post_type_name")
                .HasMaxLength(50)
                .IsRequired();

            entityType.Property(pt => pt.PostTypeValue)
                .HasColumnName("post_type_value")
                .IsRequired();

            entityType.Property(pt => pt.Description)
                .HasColumnName("description")
                .HasMaxLength(150);
        });

        builder.Entity<Post>(entityType =>
        {
            entityType.ToTable("posts");

            entityType.HasKey(p => p.Id);

            entityType.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entityType.Property(p => p.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(50);

            entityType.Property(p => p.Body)
                .HasColumnName("body")
                .IsRequired();

            entityType.Property(p => p.PostTypeId)
                .HasColumnName("post_type_id")
                .IsRequired();

            entityType.HasOne<PostType>(p => p.PostType);
        });
    }
}