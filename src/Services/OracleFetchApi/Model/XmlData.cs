using System.Xml.Linq;

namespace OracleFetchApi.Model;

public class XmlData
    {
        public XElement RootElement { get; set; }

        public static T DeserializeXml<T>(string xmlData) where T : XmlData, new()
        {
            if (string.IsNullOrEmpty(xmlData))
                return null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new StringReader(xmlData))
                {
                    var data = (T)serializer.Deserialize(reader);
                    data.RootElement = XElement.Parse(xmlData);
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing XML data: {ex.Message}");
                return null;
            }
        }
    }

    // public class Login : XmlData
    // {
    //     public string FullName { get; set; } = string.Empty;
    //     public string Environment { get; set; } = string.Empty;
    //     public string IPAddress { get; set; } = string.Empty;
    //     public DateTime Date { get; set; }
    //     public TimeSpan Time { get; set; }
    // }

    // public class Overdue : XmlData
    // {
    //     public string FullName { get; set; } = string.Empty;
    //     public string Email { get; set; } = string.Empty;
    //     public string ProductNumber { get; set; } = string.Empty;
    //     public string ProductName { get; set; } = string.Empty;
    //     public string OrderCode { get; set; } = string.Empty;
    //     public DateTime OrderDate { get; set; }
    //     public DateTime OverdueDate { get; set; }
    // }

    // public class Report : XmlData
    // {
    //     public string PortalName { get; set; } = string.Empty;
    //     public string ReportName { get; set; } = string.Empty;
    //     public string Url { get; set; } = string.Empty;
    // }

    // public class User : XmlData
    // {
    //     public string ImageHeader { get; set; } = string.Empty;
    //     public string Email { get; set; } = string.Empty;
    //     public string FullName { get; set; } = string.Empty;
    //     public string UserName { get; set; } = string.Empty;
    //     public string Password { get; set; } = string.Empty;
    //     public string Company { get; set; } = string.Empty;
    //     public string Url { get; set; } = string.Empty;
    // }