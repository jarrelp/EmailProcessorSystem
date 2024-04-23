using System.ComponentModel.DataAnnotations;

namespace FakeOracleFetchApi.Model;

public abstract class EmailTemplate
{
  // Navigatie-eigenschap voor EmailQueue
  // public EmailQueue EmailQueue { get; set; }

  [Key]
  public int Id { get; set; }

  public EmailTemplate(int id)
  {
    Id = id;
  }
}
