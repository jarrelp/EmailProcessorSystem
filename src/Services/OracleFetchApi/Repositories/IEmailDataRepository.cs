
namespace OracleFetchApi.Repositories;

public interface IEmailDataRepository
{
  Task<List<Events.IntegrationEvent>> GetIntegrationEvents(int count = 5);
  void GetAllProcessed();
  void GetAllNotPickedUp();
  void SetSentToNotPickedUp(int id);
  void SetSentToProcessed(int id);
  void SetAllSentToNotPickedUp();
  void SetSentToIsBusy(int id);
  void SetSentToError(int id);
  void SetAttempt(int id, int attempts);
  void DeleteAllEmailQueueItems();
  void GenerateEmails(int amount);
  Task<List<string>> GetColumnNamesAsync();
}
