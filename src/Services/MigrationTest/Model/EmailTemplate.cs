using System.ComponentModel.DataAnnotations;

namespace MigrationTest.Model;

public abstract class EmailTemplate
{
  [Key]
  public int Id { get; set; }

  public EmailTemplate(int id)
  {
    Id = id;
  }
}
