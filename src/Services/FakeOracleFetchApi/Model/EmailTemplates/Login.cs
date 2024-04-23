using System.ComponentModel.DataAnnotations;

namespace FakeOracleFetchApi.Model.EmailTemplates;

public class Login : EmailTemplate
{
    // [Key]
    // public int Id { get; set; }
    public string FullName { get; set; }
    public string Environment { get; set; }
    // public string IPAddress { get; set; } // Nieuwe eigenschap toegevoegd
    public string Date { get; set; }
    public string Time { get; set; }

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