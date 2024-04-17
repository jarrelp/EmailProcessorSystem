namespace EmailSendApi.Application.UseCases.ProcessEmailData;

public class ProcessEmailDataInput
{
    public int EmailQueueId { get; set; }
    public string XslName { get; set; }
    public string Email { get; set; }
    // Voeg hier andere eigenschappen toe die nodig zijn voor de verwerking van e-mailgegevens

    // Je kunt ook andere invoereigenschappen toevoegen die relevant zijn voor de verwerking van e-mailgegevens

    public ProcessEmailDataInput(int emailQueueId, string xslName, string email)
    {
        EmailQueueId = emailQueueId;
        XslName = xslName;
        Email = email;
    }
}
