using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareYou.Domain.Entities;

namespace ShareYou.Infrastructure.Database;

public class UsersDbContext : IdentityDbContext<User>
{
    public UsersDbContext() { }
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
    public virtual DbSet<WorkGroup> WorkGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany(e => e.UserGroups)
            .WithMany(e => e.UsersOfGroup);
        
        builder.Entity<WorkGroup>()
            .HasKey(e => e.ID);
        builder.Entity<WorkGroup>()
            .ComplexProperty(e => e.WhiteboardsHierarchy); // Как-то настроить
        


        base.OnModelCreating(builder);
    }
}
