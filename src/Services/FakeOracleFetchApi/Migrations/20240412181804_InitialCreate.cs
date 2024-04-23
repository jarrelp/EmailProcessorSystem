using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FakeOracleFetchApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overdue_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverdueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailQueues",
                columns: table => new
                {
                    EmailQueueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XslName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueues", x => x.EmailQueueId);
                    table.ForeignKey(
                        name: "FK_EmailQueues_EmailTemplate_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Date", "Discriminator", "Environment", "FullName", "Time" },
                values: new object[,]
                {
                    { 1, "2024-04-12", "Login", "Production", "John Doe", "20:18:03" },
                    { 2, "2024-04-12", "Login", "Production", "Gerrit Janssen", "20:18:03" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Company", "Discriminator", "User_Email", "User_FullName", "ImageHeader", "Password", "User_Url", "UserName" },
                values: new object[,]
                {
                    { 3, "Example Company", "User", "john.doe@example.com", "John Doe", "header.jpg", "password123", "http://example.com", "johndoe" },
                    { 4, "Example Company", "User", "gerrit.janssen@example.com", "Gerrit Janssen", "header.jpg", "password123", "http://example.com", "gerritjanssen" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Discriminator", "PortalName", "ReportName", "Url" },
                values: new object[,]
                {
                    { 5, "Report", "Portal X", "Monthly Sales Report", "http://example.com/reports/monthly-sales" },
                    { 6, "Report", "Portal Y", "Monthly Sales Report", "http://example.com/reports/monthly-sales" }
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                columns: new[] { "Id", "Discriminator", "Email", "Overdue_FullName", "OrderCode", "OrderDate", "OverdueDate", "ProductName", "ProductNumber" },
                values: new object[,]
                {
                    { 7, "Overdue", "john.doe@example.com", "John Doe", "ORDER1", "2024-04-05", "2024-04-12", "Product X", "PROD1" },
                    { 8, "Overdue", "gerrit.janssen@example.com", "Gerrit Janssen", "ORDER2", "2024-04-05", "2024-04-12", "Product Y", "PROD2" }
                });

            migrationBuilder.InsertData(
                table: "EmailQueues",
                columns: new[] { "EmailQueueId", "Email", "EmailTemplateId", "XslName" },
                values: new object[,]
                {
                    { 11502, "aangepast@email.adr", 1, "LOGIN" },
                    { 11503, "dizzel@dizzel.dizz", 2, "LOGIN" },
                    { 11504, "aangepast@email.adr", 7, "OVERDUE" },
                    { 11505, "dizzel@dizzel.dizz", 8, "OVERDUE" },
                    { 11506, "aangepast@email.adr", 5, "REPORT" },
                    { 11507, "dizzel@dizzel.dizz", 6, "REPORT" },
                    { 11508, "aangepast@email.adr", 3, "USER" },
                    { 11509, "dizzel@dizzel.dizz", 4, "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueues_EmailTemplateId",
                table: "EmailQueues",
                column: "EmailTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailQueues");

            migrationBuilder.DropTable(
                name: "EmailTemplate");
        }
    }
}
