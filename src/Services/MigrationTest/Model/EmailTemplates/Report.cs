namespace MigrationTest.Model.EmailTemplates;

public class Report : EmailTemplate
{
    public string PortalName { get; set; } = string.Empty;

    public string ReportName { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    // Constructor
    public Report(int id, string portalName, string reportName, string url) : base(id)
    {
        Id = id;
        PortalName = portalName;
        ReportName = reportName;
        Url = url;
    }
}
