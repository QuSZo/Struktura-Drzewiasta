using Microsoft.EntityFrameworkCore;

namespace StrukturaDrzewiasta.App.Models.DbModels;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Node> Node { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();

        modelBuilder.Entity<Node>()
            .HasMany(node => node.Nodes)
            .WithOne(node => node.ParentNode)
            .HasForeignKey(node => node.ParentNodeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}