using MigrationTest.Model.EmailTemplates;

namespace MigrationTest.Infrastructure.EntityConfigurations;
public static class GenerateSeedData
{
    public static User GenerateUserData1()
    {
        int id = 3;
        string imageHeader = "header.jpg";
        string email = "john.doe@example.com";
        string fullName = "John Doe";
        string userName = "johndoe";
        string password = "password123";
        string company = "Example Company";
        string url = "http://example.com";

        User userData = new User(id, imageHeader, email, fullName, userName, password, company, url);
        return userData;
    }

    public static User GenerateUserData2()
    {
        int id = 4;
        string imageHeader = "header.jpg";
        string email = "gerrit.janssen@example.com";
        string fullName = "Gerrit Janssen";
        string userName = "gerritjanssen";
        string password = "password123";
        string company = "Example Company";
        string url = "http://example.com";

        User userData = new User(id, imageHeader, email, fullName, userName, password, company, url);
        return userData;
    }
    public static Report GenerateReportData1()
    {
        int id = 5;
        string portalName = "Portal X";
        string reportName = "Monthly Sales Report";
        string url = "http://example.com/reports/monthly-sales";

        Report reportData = new Report(id, portalName, reportName, url);
        return reportData;
    }

    public static Report GenerateReportData2()
    {
        int id = 6;
        string portalName = "Portal Y";
        string reportName = "Monthly Sales Report";
        string url = "http://example.com/reports/monthly-sales";

        Report reportData = new Report(id, portalName, reportName, url);
        return reportData;
    }

    public static Overdue GenerateOverdueData1()
    {
        int id = 7;
        string fullName = "John Doe";
        string email = "john.doe@example.com";
        string productNumber = "PROD1";
        string productName = "Product X";
        string orderCode = "ORDER1";
        string orderDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        string overdueDate = DateTime.Now.ToString("yyyy-MM-dd");

        Overdue overdueData = new Overdue(id, fullName, email, productNumber, productName, orderCode, orderDate, overdueDate);
        return overdueData;
    }

    public static Overdue GenerateOverdueData2()
    {
        int id = 8;
        string fullName = "Gerrit Janssen";
        string email = "gerrit.janssen@example.com";
        string productNumber = "PROD2";
        string productName = "Product Y";
        string orderCode = "ORDER2";
        string orderDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        string overdueDate = DateTime.Now.ToString("yyyy-MM-dd");

        Overdue overdueData = new Overdue(id, fullName, email, productNumber, productName, orderCode, orderDate, overdueDate);
        return overdueData;
    }

    public static Login GenerateLoginData1()
    {
        int id = 1;
        string fullName = "John Doe";
        string environment = "Production";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("HH:mm:ss");

        Login loginData = new Login(id, fullName, environment, date, time);
        return loginData;
    }

    public static Login GenerateLoginData2()
    {
        int id = 2;
        string fullName = "Gerrit Janssen";
        string environment = "Production";
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string time = DateTime.Now.ToString("HH:mm:ss");

        Login loginData = new Login(id, fullName, environment, date, time);
        return loginData;
    }
}
