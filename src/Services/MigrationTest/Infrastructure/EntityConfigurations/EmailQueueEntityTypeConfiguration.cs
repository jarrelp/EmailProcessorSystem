using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTest.Model;

namespace MigrationTest.Infrastructure.EntityConfigurations;

public class EmailQueueEntityTypeConfiguration : IEntityTypeConfiguration<EmailQueue>
{
  public void Configure(EntityTypeBuilder<EmailQueue> builder)
  {
    builder.ToTable("EmailQueue");

    builder.HasKey(emailQueue => emailQueue.Id);

    // Definieer de relatie met EmailTemplate
    builder.HasOne(emailQueue => emailQueue.EmailTemplate)
        .WithMany()
        .HasForeignKey(emailQueue => emailQueue.EmailTemplateId)
        .OnDelete(DeleteBehavior.Restrict); // Voorkomt dat het verwijderen van een e-mailsjabloon de integriteit van de verwijzing verbreekt.

    builder.HasData(
        new EmailQueue(11502, "LOGIN", "aangepast@email.adr", 1),
        new EmailQueue(11503, "LOGIN", "dizzel@dizzel.dizz", 2),
        new EmailQueue(11504, "OVERDUE", "aangepast@email.adr", 7),
        new EmailQueue(11505, "OVERDUE", "dizzel@dizzel.dizz", 8),
        new EmailQueue(11506, "REPORT", "aangepast@email.adr", 5),
        new EmailQueue(11507, "REPORT", "dizzel@dizzel.dizz", 6),
        new EmailQueue(11508, "USER", "aangepast@email.adr", 3),
        new EmailQueue(11509, "USER", "dizzel@dizzel.dizz", 4)
    );
  }
}