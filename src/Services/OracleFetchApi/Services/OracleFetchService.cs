using OracleFetchApi.Repositories;
using OracleFetchApi.ViewModel;
using OracleFetchApi.ViewModel.EmailTemplates;

namespace OracleFetchApi.Services;

public class OracleFetchService : IOracleFetchService
{
    private readonly IOracleFetchRepository _oracleFetchRepository;

    public OracleFetchService(IOracleFetchRepository oracleFetchRepository)
    {
        _oracleFetchRepository = oracleFetchRepository;
    }

    // Methode om alle e-mailwachtrijen op te halen
    public async Task<List<EmailQueueViewModel>> GetAllEmailQueuesAsync()
    {
        var emailQueues = await _oracleFetchRepository.GetAllAsync();

        var emailQueueViewModels = new List<EmailQueueViewModel>();

        foreach (var emailQueue in emailQueues)
        {
            var emailQueueDto = new EmailQueueViewModel
            {
                Email = emailQueue.Email,
                XslName = emailQueue.XslName,
                EmailQueueId = emailQueue.EmailQueueId,
                EmailTemplateId = emailQueue.EmailTemplateId,
                EmailTemplate = MapToDto(emailQueue.EmailTemplate)
            };

            emailQueueViewModels.Add(emailQueueDto);
        }

        return emailQueueViewModels;
    }

    // Methode om een enkele e-mailwachtrij op te halen op basis van de ID
    public async Task<EmailQueueViewModel> GetEmailQueueByIdAsync(int id)
    {
        var emailQueue = await _oracleFetchRepository.GetByIdAsync(id);
        if (emailQueue == null)
        {
            throw new Exception($"EmailQueue with id {id} not found");
        }

        var emailQueueViewModel = new EmailQueueViewModel
        {
            Email = emailQueue.Email,
            XslName = emailQueue.XslName,
            EmailQueueId = emailQueue.EmailQueueId,
            EmailTemplateId = emailQueue.EmailTemplateId,
            EmailTemplate = MapToDto(emailQueue.EmailTemplate)
        };

        // // Mapping van het domeinmodel naar een DTO-object
        // var emailQueueDto = _mapper.Map<EmailQueueDto>(emailQueue);

        // return emailQueueDto;

        return emailQueueViewModel;
    }

    // Methode om e-mailwachtrij toe te voegen
    public async Task AddEmailQueueAsync(EmailQueue emailQueue)
    {
        await _oracleFetchRepository.AddAsync(emailQueue);
    }

    // Methode om e-mailwachtrij bij te werken
    public async Task UpdateEmailQueueAsync(EmailQueue emailQueue)
    {
        await _oracleFetchRepository.UpdateAsync(emailQueue);
    }

    // Methode om e-mailwachtrij te verwijderen
    public async Task DeleteEmailQueueAsync(int id)
    {
        var emailQueue = await _oracleFetchRepository.GetByIdAsync(id);
        if (emailQueue != null)
        {
            await _oracleFetchRepository.DeleteAsync(emailQueue);
        }
    }

    private object MapToDto(EmailTemplate emailTemplate)
    {
        switch (emailTemplate)
        {
            case Login loginTemplate:
                return new LoginViewModel
                {
                    Id = loginTemplate.Id,
                    FullName = loginTemplate.FullName,
                    Environment = loginTemplate.Environment,
                    Date = loginTemplate.Date,
                    Time = loginTemplate.Time
                };
            case Overdue overdueTemplate:
                return new OverdueViewModel
                {
                    Id = overdueTemplate.Id,
                    FullName = overdueTemplate.FullName,
                    Email = overdueTemplate.Email,
                    ProductNumber = overdueTemplate.ProductNumber,
                    ProductName = overdueTemplate.ProductName,
                    OrderCode = overdueTemplate.OrderCode,
                    OrderDate = overdueTemplate.OrderDate,
                    OverdueDate = overdueTemplate.OverdueDate
                };
            case Report reportTemplate:
                return new ReportViewModel
                {
                    Id = reportTemplate.Id,
                    PortalName = reportTemplate.PortalName,
                    ReportName = reportTemplate.ReportName,
                    Url = reportTemplate.Url
                };
            case User userTemplate:
                return new UserViewModel
                {
                    Id = userTemplate.Id,
                    ImageHeader = userTemplate.ImageHeader,
                    Email = userTemplate.Email,
                    FullName = userTemplate.FullName,
                    UserName = userTemplate.UserName,
                    Password = userTemplate.Password,
                    Company = userTemplate.Company,
                    Url = userTemplate.Url
                };
            default:
                return null; // Of eventueel een leeg EmailTemplateDto object, afhankelijk van de logica van je applicatie
        }
    }
}