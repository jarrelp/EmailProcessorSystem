using System.ComponentModel.DataAnnotations;

namespace MigrationTest.Model;

public class EmailQueue
{
  public int Id { get; set; }

  // public string Subject { get; set; }
  // public int Attempts { get; set; }
  // public bool Sent { get; set; }
  // public int CompanyId { get; set; }
  // public string SendAt { get; set; }
  public string Email { get; set; } = string.Empty;
  // public string IsoLanguage { get; set; }
  public string XslName { get; set; } = string.Empty;

  // Soort Email
  // public string XmlData { get; set; } // xml data


  public int EmailTemplateId { get; set; }
  public EmailTemplate EmailTemplate { get; set; } = null!;

  // Constructor
  // public EmailQueue(string subject, int attempts, bool sent, int companyId, string sendAt, string email, string isoLanguage, string xslName, string xmlData, int id)
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
  //   Id = id;
  // }

  public EmailQueue(int id, string xslName, string email, int emailTemplateId)
  {
    Id = id;
    XslName = xslName;
    Email = email;
    EmailTemplateId = emailTemplateId;
  }
}

