using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace InspoWork.Data;

public class InspoWorkDbContext : DbContext
{
    public InspoWorkDbContext(DbContextOptions<InspoWorkDbContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Post>().ToCollection("posts");
    }
    
    public required DbSet<Post> Posts { get; set; }
}