using InspoWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InspoWork.Data;

public class IrohDbContext : DbContext
{
    public IrohDbContext(DbContextOptions<IrohDbContext> options)
        : base(options)
    { }
    
    public DbSet<Post>? Posts { get; set; }
}