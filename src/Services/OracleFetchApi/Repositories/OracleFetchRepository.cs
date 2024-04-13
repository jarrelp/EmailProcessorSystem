namespace OracleFetchApi.Repositories;

public class OracleFetchRepository : IOracleFetchRepository
{
  private readonly OracleDbContext _context;

  public OracleFetchRepository(OracleDbContext context)
  {
    _context = context;
  }

  public async Task<List<EmailQueue>> GetAllAsync()
  {
    return await _context.EmailQueues
      .Include(eq => eq.EmailTemplate)
      .ToListAsync();
  }

  public async Task<EmailQueue> GetByIdAsync(int id)
  {
    return await _context.EmailQueues
      .Include(eq => eq.EmailTemplate)
      .FirstOrDefaultAsync(eq => eq.EmailQueueId == id);
  }

  public async Task AddAsync(EmailQueue emailQueue)
  {
    await _context.EmailQueues.AddAsync(emailQueue);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(EmailQueue emailQueue)
  {
    _context.Entry(emailQueue).State = EntityState.Modified;
    await _context.SaveChangesAsync();
  }

  public async Task DeleteAsync(EmailQueue emailQueue)
  {
    _context.EmailQueues.Remove(emailQueue);
    await _context.SaveChangesAsync();
  }
}
