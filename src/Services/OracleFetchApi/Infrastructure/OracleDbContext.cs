using OracleFetchApi.Infrastructure.EntityConfigurations;

namespace OracleFetchApi.Infrastructure;

public class OracleDbContext : DbContext
{
  public DbSet<EmailQueue> EmailQueues { get; set; }

  // public DbSet<EmailTemplate> EmailTemplates { get; set; }
  public DbSet<Login> Logins { get; set; }
  public DbSet<Overdue> Overdues { get; set; }
  public DbSet<Report> Reports { get; set; }
  public DbSet<User> Users { get; set; }

  // // Orders
  // public DbSet<Order> Orders { get; set; }


  public OracleDbContext(DbContextOptions<OracleDbContext> options)
      : base(options)
  { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    var login1 = GenerateSeedData.GenerateLoginData1();
    var login2 = GenerateSeedData.GenerateLoginData2();
    var overdue1 = GenerateSeedData.GenerateOverdueData1();
    var overdue2 = GenerateSeedData.GenerateOverdueData2();
    var report1 = GenerateSeedData.GenerateReportData1();
    var report2 = GenerateSeedData.GenerateReportData2();
    var user1 = GenerateSeedData.GenerateUserData1();
    var user2 = GenerateSeedData.GenerateUserData2();

    // Zaadgegevens voor EmailTemplate
    builder.Entity<Login>().HasData(login1, login2);
    builder.Entity<Overdue>().HasData(overdue1, overdue2);
    builder.Entity<Report>().HasData(report1, report2);
    builder.Entity<User>().HasData(user1, user2);

    // Relatie zaadgegevens toevoegen
    builder.Entity<EmailQueue>().HasData(
        new EmailQueue(11502, "LOGIN", "aangepast@email.adr") { EmailTemplateId = login1.Id },
        new EmailQueue(11503, "LOGIN", "dizzel@dizzel.dizz") { EmailTemplateId = login2.Id },
        new EmailQueue(11504, "OVERDUE", "aangepast@email.adr") { EmailTemplateId = overdue1.Id },
        new EmailQueue(11505, "OVERDUE", "dizzel@dizzel.dizz") { EmailTemplateId = overdue2.Id },
        new EmailQueue(11506, "REPORT", "aangepast@email.adr") { EmailTemplateId = report1.Id },
        new EmailQueue(11507, "REPORT", "dizzel@dizzel.dizz") { EmailTemplateId = report2.Id },
        new EmailQueue(11508, "USER", "aangepast@email.adr") { EmailTemplateId = user1.Id },
        new EmailQueue(11509, "USER", "dizzel@dizzel.dizz") { EmailTemplateId = user2.Id }
    );

    // // builder.ApplyConfiguration(new EmailQueueEntityTypeConfiguration());

    // // builder.Entity<EmailTemplate>().ToTable("EmailTemplate");

    // builder.Entity<EmailQueue>().ToTable("EmailQueues");

    // var login1 = GenerateSeedData.GenerateLoginData1();
    // var login2 = GenerateSeedData.GenerateLoginData2();
    // var overdue1 = GenerateSeedData.GenerateOverdueData1();
    // var overdue2 = GenerateSeedData.GenerateOverdueData2();
    // var report1 = GenerateSeedData.GenerateReportData1();
    // var report2 = GenerateSeedData.GenerateReportData2();
    // var user1 = GenerateSeedData.GenerateUserData1();
    // var user2 = GenerateSeedData.GenerateUserData2();

    // var email3 = new EmailQueue(11502, "LOGIN", "aangepast@email.adr")
    // {
    //   EmailTemplate = login1
    // };
    // var email4 = new EmailQueue(11503, "LOGIN", "dizzel@dizzel.dizz")
    // {
    //   EmailTemplate = login2
    // };
    // var email5 = new EmailQueue(11504, "OVERDUE", "aangepast@email.adr")
    // {
    //   EmailTemplate = overdue1
    // };
    // var email6 = new EmailQueue(11505, "OVERDUE", "dizzel@dizzel.dizz")
    // {
    //   EmailTemplate = overdue2
    // };
    // var email7 = new EmailQueue(11506, "REPORT", "aangepast@email.adr")
    // {
    //   EmailTemplate = report1
    // };
    // var email8 = new EmailQueue(11507, "REPORT", "dizzel@dizzel.dizz")
    // {
    //   EmailTemplate = report2
    // };
    // var email9 = new EmailQueue(11508, "USER", "aangepast@email.adr")
    // {
    //   EmailTemplate = user1
    // };
    // var email10 = new EmailQueue(11509, "USER", "dizzel@dizzel.dizz")
    // {
    //   EmailTemplate = user2
    // };

    // builder.Entity<Login>()
    //     // .ToTable("Logins")
    //     .HasData(login1, login2);

    // builder.Entity<Overdue>()
    //     // .ToTable("Overdues")
    //     .HasData(overdue1, overdue2);

    // builder.Entity<Report>()
    //     // .ToTable("Reports")
    //     .HasData(report1, report2);

    // builder.Entity<User>()
    //     // .ToTable("Users")
    //     .HasData(user1, user2);

    // // builder.Entity<EmailTemplate>()
    // //     .ToTable("EmailTemplates")
    // //     .HasDiscriminator<string>("EmailType")
    // //     .HasValue<Login>("Login")
    // //     .HasValue<Overdue>("Overdue")
    // //     .HasValue<Report>("Report")
    // //     .HasValue<User>("User");

    // // Relatie zaadgegevens toevoegen
    // builder.Entity<EmailQueue>()
    //     .HasOne(e => e.EmailTemplate)
    //     .WithMany() // Geen 'WithOne' omdat EmailTemplate niet refereert aan EmailQueue
    //     .HasForeignKey(e => e.EmailQueueId) // Moet verwijzen naar de Id van EmailTemplate
    //     .IsRequired(); // Vereisen dat de relatie aanwezig is

    // builder.Entity<EmailQueue>()
    //     .HasData(email3, email4, email5, email6, email7, email8, email9, email10);

    // // builder.Entity<EmailQueue>()
    // //     .HasOne(e => e.EmailTemplate)
    // //     .WithOne()
    // //     .HasForeignKey<EmailTemplate>(e => e.Id);


    // // Orders
    // // builder.Entity<Order>().ToTable("Orders");


  }

  // The following configures EF to create a Sqlite database file in the
  // special "local" folder for your platform.
  // protected override void OnConfiguring(DbContextOptionsBuilder options)
  //     => options.UseSqlite($"Data Source={DbPath}");
}
