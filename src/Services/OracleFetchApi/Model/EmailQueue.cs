using System.ComponentModel.DataAnnotations;

namespace OracleFetchApi.Model;

public class EmailQueue
{
  // public string Subject { get; set; }
  public int Attempts { get; set; }
  public string Sent { get; set; }
  // public int CompanyId { get; set; }
  public string SendAt { get; set; }
  public string Email { get; set; }
  // public string IsoLanguage { get; set; }
  public string XslName { get; set; } // Soort Email
  // public string XmlData { get; set; } // xml data
  public int EmailQueueId { get; set; }

  public int EmailTemplateId { get; set; }
  public EmailTemplate EmailTemplate { get; set; }

  // Constructor
  // public EmailQueue(string subject, int attempts, bool sent, int companyId, string sendAt, string email, string isoLanguage, string xslName, string xmlData, int emailQueueId)
  // {
  //   Subject = subject;
  //   Attempts = attempts;
  //   Sent = sent;
  //   CompanyId = companyId;
  //   SendAt = sendAt;
  //   Email = email;
  //   IsoLanguage = isoLanguage;
  //   XslName = xslName;
  //   XmlData = xmlData;
  //   EmailQueueId = emailQueueId;
  // }

  public EmailQueue(int emailQueueId, string xslName, string email)
  {
    EmailQueueId = emailQueueId;
    XslName = xslName;
    Email = email;
  }
}

