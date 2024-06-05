using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MigrationTest.Model.EmailTemplates;

namespace MigrationTest.Infrastructure.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        // builder.HasKey(user => user.Id);

        // builder.Property(user => user.Id)
        //     .UseHiLo("user_hilo")
        //     .IsRequired();

        var user1 = GenerateSeedData.GenerateUserData1();
        var user2 = GenerateSeedData.GenerateUserData2();

        builder.HasData(
            user1, user2
        );
    }
}
