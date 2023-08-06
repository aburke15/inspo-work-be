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
}