using Microsoft.EntityFrameworkCore;
using ShareYou.Domain.Entities;

namespace ShareYou.Infrastructure.Database;
public class MessagesDbContext : DbContext
{
    public MessagesDbContext() { }
    public MessagesDbContext(DbContextOptions options) : base(options) { }
    public virtual DbSet<Message> Messages { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}

