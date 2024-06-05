using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;

namespace OracleFetchApi.Model.EmailTemplates;

public class Login : XmlData
{
    public string FullName { get; set; }
    public string Environment { get; set; }
    public string IPAddress { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }

    public static Login Deserialize(string xmlData)
    {
        var element = XElement.Parse(xmlData);

        return new Login
        {
            FullName = element.Element("fullname")?.Value,
            Environment = element.Element("environment")?.Value,
            IPAddress = element.Element("ipaddress")?.Value,
            Date = DateTime.Parse(element.Element("date")?.Value),
            Time = TimeSpan.Parse(element.Element("time")?.Value)
        };
    }

    // public Login(string fullName, string environment,
    // string iPAddress,
    // string date, string time)
    // {
    //     FullName = fullName;
    //     Environment = environment;
    //     IPAddress = iPAddress;
    //     Date = date;
    //     Time = time;
    // }
}