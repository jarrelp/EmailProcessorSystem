using Microsoft.EntityFrameworkCore;
using MigrationTest.Infrastructure.EntityConfigurations;
using MigrationTest.Model;
using MigrationTest.Model.EmailTemplates;

namespace MigrationTest.Infrastructure;

public class OracleTestDbContext : DbContext
{
  public OracleTestDbContext(DbContextOptions<OracleTestDbContext> options)
      : base(options)
  { }

  public DbSet<EmailQueue> EmailQueues => Set<EmailQueue>();
  public DbSet<Login> Logins => Set<Login>();
  public DbSet<Overdue> Overdues => Set<Overdue>();
  public DbSet<Report> Reports => Set<Report>();
  public DbSet<User> Users => Set<User>();

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.ApplyConfiguration(new LoginEntityTypeConfiguration());
    builder.ApplyConfiguration(new OverdueEntityTypeConfiguration());
    builder.ApplyConfiguration(new ReportEntityTypeConfiguration());
    builder.ApplyConfiguration(new UserEntityTypeConfiguration());
    builder.ApplyConfiguration(new EmailQueueEntityTypeConfiguration());
  }
}