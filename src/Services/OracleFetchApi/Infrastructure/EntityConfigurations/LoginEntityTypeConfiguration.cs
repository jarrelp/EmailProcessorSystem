using OracleFetchApi.Model.EmailTemplates;

namespace OracleFetchApi.Infrastructure.EntityConfigurations;

public class LoginEntityTypeConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.ToTable("Login");

        var login1 = GenerateSeedData.GenerateLoginData1();
        var login2 = GenerateSeedData.GenerateLoginData2();

        builder.HasData(
            login1, login2
        );
    }
}
