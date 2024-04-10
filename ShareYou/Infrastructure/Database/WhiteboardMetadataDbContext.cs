using Microsoft.EntityFrameworkCore;
using ShareYou.Application.SecretsManagement;
using ShareYou.Domain.Entities;

namespace ShareYou.Infrastructure.Database;

public class WhiteboardMetadataDbContext : DbContext
{
    private readonly ISecretsManager _secretsManager;
    public WhiteboardMetadataDbContext(ISecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }
    public WhiteboardMetadataDbContext() { }
    public WhiteboardMetadataDbContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<WhiteboardMetadata> WhiteboardsMetadata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (builder.IsConfigured) return;

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<WhiteboardMetadata>()
            .HasKey(e => e.ID);
        builder.Entity<WhiteboardMetadata>()
            .Property(e => e.WhiteboardType)
            .HasConversion<int>();
        // later
    }

}
