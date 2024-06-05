namespace OracleFetchApi.Model.EmailTemplates;

public class User : XmlData
{
    public string Url { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public string PersonIdExtern { get; set; }
    public string FullName { get; set; }
    public string Street { get; set; }
    public string PrimaryNumber { get; set; }
    public string AdditionalNumber { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    // public User(string imageHeader, string email, string fullName, string userName, string password, string company, string url)
    // {
    //     ImageHeader = imageHeader;
    //     Email = email;
    //     FullName = fullName;
    //     UserName = userName;
    //     Password = password;
    //     Company = company;
    //     Url = url;
    // }
}