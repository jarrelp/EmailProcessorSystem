using System.Xml.Linq;

namespace OracleFetchApi.Model.EmailTemplates;

public class Login : XmlData
{
    public string? FullName { get; set; }
    public string? Environment { get; set; }
    public string? IPAddress { get; set; }
    public DateTime? Date { get; set; }
    public TimeSpan? Time { get; set; }
}