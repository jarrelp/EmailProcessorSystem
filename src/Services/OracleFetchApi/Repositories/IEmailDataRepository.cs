
namespace OracleFetchApi.Repositories;

public interface IEmailDataRepository
{
  void GetAll();
  void GetAllNotPickedUp();
  void GetByEmailQueueId(int id);
  void SetSent(int id, string newSentValue);
  Task<List<string>> GetColumnNamesAsync();
  Task<List<EmailQueueItem>> GetTopEmailQueueItemsAsync(int count);
  Task<List<EmailQueueItem>> GetXmlData(int count);
}
