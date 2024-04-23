using System.ComponentModel.DataAnnotations;

namespace FakeOracleFetchApi.Model.EmailTemplates;

public class User : EmailTemplate
{
    // [Key]
    // public int Id { get; set; }
    public string ImageHeader { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Company { get; set; }

    public string Url { get; set; }

    // Constructor
    public User(int id, string imageHeader, string email, string fullName, string userName, string password, string company, string url) : base(id)
    {
        Id = id;
        ImageHeader = imageHeader;
        Email = email;
        FullName = fullName;
        UserName = userName;
        Password = password;
        Company = company;
        Url = url;
    }
}
