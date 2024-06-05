using System.ComponentModel.DataAnnotations;

namespace OracleFetchApi.Model.EmailTemplates;

public class Report : XmlData
{
    public string PortalName { get; set; }
    public string ReportName { get; set; }
    public string Url { get; set; }

    // public Report(string portalName, string reportName, string url)
    // {
    //     PortalName = portalName;
    //     ReportName = reportName;
    //     Url = url;
    // }
}
