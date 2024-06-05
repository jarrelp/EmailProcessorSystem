namespace MigrationTest.Model.EmailTemplates;

public class Login : EmailTemplate
{
    public string FullName { get; set; } = string.Empty;
    public string Environment { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;

    public Login(int id, string fullName, string environment,
    // string ipAddress, 
    string date, string time) : base(id)
    {
        Id = id;
        FullName = fullName;
        Environment = environment;
        // IPAddress = ipAddress;
        Date = date;
        Time = time;
    }
}