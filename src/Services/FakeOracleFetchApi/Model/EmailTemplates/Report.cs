using System.ComponentModel.DataAnnotations;

namespace FakeOracleFetchApi.Model.EmailTemplates;

public class Report : EmailTemplate
{
    // [Key]
    // public int Id { get; set; }
    public string PortalName { get; set; }

    public string ReportName { get; set; }

    public string Url { get; set; }

    // Constructor
    public Report(int id, string portalName, string reportName, string url) : base(id)
    {
        Id = id;
        PortalName = portalName;
        ReportName = reportName;
        Url = url;
    }
}
