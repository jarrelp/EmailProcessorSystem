namespace FakeOracleFetchApi.ViewModel;

public class EmailQueueViewModel
{
    public string Email { get; set; }
    public string XslName { get; set; }
    public int EmailQueueId { get; set; }
    public int EmailTemplateId { get; set; }
    public object EmailTemplate { get; set; } // Dit kan worden vervangen door het specifieke ViewModel van de e-mailsjabloon, afhankelijk van de logica van je applicatie
}
