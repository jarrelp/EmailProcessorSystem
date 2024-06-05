using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTest.Model.EmailTemplates;

namespace MigrationTest.Infrastructure.EntityConfigurations;

public class ReportEntityTypeConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Report");

        // builder.HasKey(report => report.Id);

        // builder.Property(report => report.Id)
        //     .UseHiLo("report_hilo")
        //     .IsRequired();

        var report1 = GenerateSeedData.GenerateReportData1();
        var report2 = GenerateSeedData.GenerateReportData2();

        builder.HasData(
            report1, report2
        );
    }
}
