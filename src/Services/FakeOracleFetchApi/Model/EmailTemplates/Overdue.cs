using System.ComponentModel.DataAnnotations;

namespace FakeOracleFetchApi.Model.EmailTemplates;

public class Overdue : EmailTemplate
{
    // [Key]
    // public int Id { get; set; }
    public string FullName { get; set; }

    public string Email { get; set; }

    public string ProductNumber { get; set; }

    public string ProductName { get; set; }

    public string OrderCode { get; set; }
    public string OrderDate { get; set; }

    public string OverdueDate { get; set; }

    // Constructor
    public Overdue(int id, string fullName, string email, string productNumber, string productName, string orderCode, string orderDate, string overdueDate) : base(id)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        ProductNumber = productNumber;
        ProductName = productName;
        OrderCode = orderCode;
        OrderDate = orderDate;
        OverdueDate = overdueDate;
    }
}
