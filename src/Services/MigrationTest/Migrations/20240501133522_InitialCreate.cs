using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MigrationTest.Migrations
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
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailQueue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XslName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailQueue_EmailTemplate_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Login_EmailTemplate_Id",
                        column: x => x.Id,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Overdue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverdueDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overdue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Overdue_EmailTemplate_Id",
                        column: x => x.Id,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PortalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_EmailTemplate_Id",
                        column: x => x.Id,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ImageHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_EmailTemplate_Id",
                        column: x => x.Id,
                        principalTable: "EmailTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplate",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8
                });

            migrationBuilder.InsertData(
                table: "EmailQueue",
                columns: new[] { "Id", "Email", "EmailTemplateId", "XslName" },
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

            migrationBuilder.InsertData(
                table: "Login",
                columns: new[] { "Id", "Date", "Environment", "FullName", "Time" },
                values: new object[,]
                {
                    { 1, "2024-05-01", "Production", "John Doe", "15:35:22" },
                    { 2, "2024-05-01", "Production", "Gerrit Janssen", "15:35:22" }
                });

            migrationBuilder.InsertData(
                table: "Overdue",
                columns: new[] { "Id", "Email", "FullName", "OrderCode", "OrderDate", "OverdueDate", "ProductName", "ProductNumber" },
                values: new object[,]
                {
                    { 7, "john.doe@example.com", "John Doe", "ORDER1", "2024-04-24", "2024-05-01", "Product X", "PROD1" },
                    { 8, "gerrit.janssen@example.com", "Gerrit Janssen", "ORDER2", "2024-04-24", "2024-05-01", "Product Y", "PROD2" }
                });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "PortalName", "ReportName", "Url" },
                values: new object[,]
                {
                    { 5, "Portal X", "Monthly Sales Report", "http://example.com/reports/monthly-sales" },
                    { 6, "Portal Y", "Monthly Sales Report", "http://example.com/reports/monthly-sales" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Company", "Email", "FullName", "ImageHeader", "Password", "Url", "UserName" },
                values: new object[,]
                {
                    { 3, "Example Company", "john.doe@example.com", "John Doe", "header.jpg", "password123", "http://example.com", "johndoe" },
                    { 4, "Example Company", "gerrit.janssen@example.com", "Gerrit Janssen", "header.jpg", "password123", "http://example.com", "gerritjanssen" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailQueue_EmailTemplateId",
                table: "EmailQueue",
                column: "EmailTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailQueue");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Overdue");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "EmailTemplate");
        }
    }
}
