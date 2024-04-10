using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ShareYou.Domain.Entities;

namespace ShareYou.Infrastructure.WhiteboardStorage;
public class WhiteboardDbContext : DbContext
{
    public WhiteboardDbContext() { }
    public WhiteboardDbContext(DbContextOptions options) : base(options) { }
    public virtual DbSet<Whiteboard> Whiteboards { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Whiteboard>()
            .HasKey(e => e.ID);
        builder.Entity<Whiteboard>()
            .Property(e => e.Data)
            .HasColumnType("BLOB");
    }
}

