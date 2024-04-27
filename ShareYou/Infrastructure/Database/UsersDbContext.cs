using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareYou.Application.SecretsManagement;
using ShareYou.Domain.Entities;

namespace ShareYou.Infrastructure.Database;

public class UsersDbContext : IdentityDbContext<User>
{
    private readonly ISecretsManager _secretsManager;
    public UsersDbContext(ISecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
    public virtual DbSet<WorkGroup> WorkGroups { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        var connectionString = _secretsManager.GetDbConnectionString(this.GetType().Name);
        builder.UseNpgsql(connectionString);
    }
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
