using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace InspoWork.Data;

public class InspoWorkDbContext : DbContext
{
    public InspoWorkDbContext(DbContextOptions<InspoWorkDbContext> options) : base(options)
    { }

    public DbSet<PostType> PostTypes { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Post>().ToCollection("posts");
        builder.Entity<PostType>().ToCollection("post_types");
    }
}