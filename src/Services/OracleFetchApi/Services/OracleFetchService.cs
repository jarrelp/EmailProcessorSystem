using OracleFetchApi.Repositories;

namespace OracleFetchApi.Services;

public class OracleFetchService : IOracleFetchService
{
    private readonly IOracleFetchRepository _oracleFetchRepository;

    public OracleFetchService(IOracleFetchRepository oracleFetchRepository)
    {
        _oracleFetchRepository = oracleFetchRepository;
    }

    // Methode om alle e-mailwachtrijen op te halen
    public async Task<List<EmailQueue>> GetAllEmailQueuesAsync()
    {
        return await _oracleFetchRepository.GetAllAsync();
    }

    // Methode om een enkele e-mailwachtrij op te halen op basis van de ID
    public async Task<EmailQueue> GetEmailQueueByIdAsync(int id)
    {
        var emailQueue = await _oracleFetchRepository.GetByIdAsync(id);
        if (emailQueue == null)
        {
            throw new Exception($"EmailQueue with id {id} not found");
        }

        // // Mapping van het domeinmodel naar een DTO-object
        // var emailQueueDto = _mapper.Map<EmailQueueDto>(emailQueue);

        // return emailQueueDto;

        return emailQueue;
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
}
