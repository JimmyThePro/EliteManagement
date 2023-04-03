using EliteManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EliteManagement.Contexts;

internal class DataContext : DbContext
{
    #region constructors & overrides
    protected DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jimmy\source\repos\EliteManagement\EliteManagement\Contexts\elitemanagement_db.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    #endregion

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserTypeEntity> UserTypes { get; set; }
    public DbSet<StatusTypeEntity> StatusTypes { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<CaseEntity> Cases { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
}
