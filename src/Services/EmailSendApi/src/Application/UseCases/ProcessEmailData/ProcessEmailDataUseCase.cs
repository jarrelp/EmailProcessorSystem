namespace EmailSendApi.Application.UseCases.ProcessEmailData;

public class ProcessEmailDataUseCase
{
    private readonly IEmailTemplateRepository _emailTemplateRepository;
    private readonly IEmailContentGenerator _emailContentGenerator;
    private readonly IPubSubClient _pubSubClient;

    public ProcessEmailDataUseCase(
        IEmailTemplateRepository emailTemplateRepository,
        IEmailContentGenerator emailContentGenerator,
        IPubSubClient pubSubClient)
    {
        _emailTemplateRepository = emailTemplateRepository;
        _emailContentGenerator = emailContentGenerator;
        _pubSubClient = pubSubClient;
    }

    public async Task ExecuteAsync(EmailQueue emailQueue)
    {
        // Haal het juiste e-mailtemplate op basis van de e-mailqueue op
        var emailTemplate = await _emailTemplateRepository.GetEmailTemplateByIdAsync(emailQueue.EmailTemplateId);

        // Genereer e-mailinhoud op basis van het e-mailtemplate en de e-mailgegevens
        var emailContent = _emailContentGenerator.GenerateEmailContent(emailTemplate, emailQueue);

        // Publiceer een domein gebeurtenis om aan te geven dat de e-mail klaar is om te worden verzonden
        var emailReadyToSendEvent = MapToEmailReadyToSendEvent(emailQueue, emailContent);
        await _pubSubClient.PublishAsync(emailReadyToSendEvent);
    }

    private EmailReadyToSendEvent MapToEmailReadyToSendEvent(EmailQueue emailQueue, string emailContent)
    {
        // Map e-mailgegevens naar domein gebeurtenis
        return emailQueue.XslName switch
        {
            "LOGIN" => new LoginEmail(emailQueue.EmailQueueId, emailContent),
            "OVERDUE" => new OverdueEmail(emailQueue.EmailQueueId, emailContent),
            "REPORT" => new ReportEmail(emailQueue.EmailQueueId, emailContent),
            "USER" => new UserEmail(emailQueue.EmailQueueId, emailContent),
            _ => null, // Of eventueel een leeg EmailReadyToSendEvent object, afhankelijk van de logica van je applicatie
        };
    }
}