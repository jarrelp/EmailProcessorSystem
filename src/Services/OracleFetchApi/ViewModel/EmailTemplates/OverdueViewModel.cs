namespace OracleFetchApi.ViewModel.EmailTemplates;

public class OverdueViewModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string ProductNumber { get; set; }
    public string ProductName { get; set; }
    public string OrderCode { get; set; }
    public string OrderDate { get; set; }
    public string OverdueDate { get; set; }
}
