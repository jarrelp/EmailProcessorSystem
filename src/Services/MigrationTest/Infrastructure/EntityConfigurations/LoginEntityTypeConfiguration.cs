using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTest.Model.EmailTemplates;

namespace MigrationTest.Infrastructure.EntityConfigurations;

public class LoginEntityTypeConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.ToTable("Login");

        // builder.HasKey(login => login.Id);

        // builder.Property(login => login.Id)
        //     .UseHiLo("login_hilo")
        //     .IsRequired();

        var login1 = GenerateSeedData.GenerateLoginData1();
        var login2 = GenerateSeedData.GenerateLoginData2();

        builder.HasData(
            login1, login2
        );
    }
}
