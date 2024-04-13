namespace OracleFetchApi.Services;

public interface IOracleFetchService
{
    Task<List<EmailQueue>> GetAllEmailQueuesAsync();
    Task<EmailQueue> GetEmailQueueByIdAsync(int id);
    Task AddEmailQueueAsync(EmailQueue emailQueue);
    Task UpdateEmailQueueAsync(EmailQueue emailQueue);
    Task DeleteEmailQueueAsync(int id);
}
