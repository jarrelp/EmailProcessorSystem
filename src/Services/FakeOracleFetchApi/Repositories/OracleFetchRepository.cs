namespace FakeOracleFetchApi.Repositories;

public class OracleFetchRepository : IOracleFetchRepository
{
  private readonly OracleDbContext _context;

  public OracleFetchRepository(OracleDbContext context)
  {
    _context = context;
  }

  public async Task<List<EmailQueue>> GetAllAsync()
  {
    var emailQueues = await _context.EmailQueues
        .Include(eq => eq.EmailTemplate)
        .ToListAsync();

    // foreach (var emailQueue in emailQueues)
    // {
    //   if (emailQueue.EmailTemplate != null)
    //   {
    //     Console.WriteLine($"EmailQueueId: {emailQueue.EmailQueueId}, EmailTemplate Type: {emailQueue.EmailTemplate.GetType().Name}");
    //   }
    //   else
    //   {
    //     Console.WriteLine($"EmailQueueId: {emailQueue.EmailQueueId}, EmailTemplate: null");
    //   }
    // }

    foreach (var emailQueue in emailQueues)
    {
      if (emailQueue.EmailTemplate != null)
      {
        Console.WriteLine($"EmailQueueId: {emailQueue.EmailQueueId}, EmailTemplate Type: {emailQueue.EmailTemplate.GetType().Name}");

        switch (emailQueue.EmailTemplate)
        {
          case Login loginTemplate:
            Console.WriteLine($"Login Template Attributes:");
            Console.WriteLine($"  FullName: {loginTemplate.FullName}");
            Console.WriteLine($"  Environment: {loginTemplate.Environment}");
            Console.WriteLine($"  Date: {loginTemplate.Date}");
            Console.WriteLine($"  Time: {loginTemplate.Time}");
            break;
          case Overdue overdueTemplate:
            Console.WriteLine($"Overdue Template Attributes:");
            Console.WriteLine($"  FullName: {overdueTemplate.FullName}");
            Console.WriteLine($"  Email: {overdueTemplate.Email}");
            Console.WriteLine($"  ProductNumber: {overdueTemplate.ProductNumber}");
            Console.WriteLine($"  ProductName: {overdueTemplate.ProductName}");
            Console.WriteLine($"  OrderCode: {overdueTemplate.OrderCode}");
            Console.WriteLine($"  OrderDate: {overdueTemplate.OrderDate}");
            Console.WriteLine($"  OverdueDate: {overdueTemplate.OverdueDate}");
            break;
          case Report reportTemplate:
            Console.WriteLine($"Report Template Attributes:");
            Console.WriteLine($"  PortalName: {reportTemplate.PortalName}");
            Console.WriteLine($"  ReportName: {reportTemplate.ReportName}");
            Console.WriteLine($"  Url: {reportTemplate.Url}");
            break;
          case User userTemplate:
            Console.WriteLine($"User Template Attributes:");
            Console.WriteLine($"  ImageHeader: {userTemplate.ImageHeader}");
            Console.WriteLine($"  Email: {userTemplate.Email}");
            Console.WriteLine($"  FullName: {userTemplate.FullName}");
            Console.WriteLine($"  UserName: {userTemplate.UserName}");
            Console.WriteLine($"  Password: {userTemplate.Password}");
            Console.WriteLine($"  Company: {userTemplate.Company}");
            Console.WriteLine($"  Url: {userTemplate.Url}");
            break;
        }
      }
      else
      {
        Console.WriteLine($"EmailQueueId: {emailQueue.EmailQueueId}, EmailTemplate: null");
      }
    }

    // foreach (var emailQueue in emailQueues)
    // {
    //   if (emailQueue != null && emailQueue.EmailTemplate != null)
    //   {
    //     switch (emailQueue.EmailTemplate)
    //     {
    //       case Login loginTemplate:
    //         emailQueue.EmailTemplate = loginTemplate;
    //         break;
    //       case Overdue overdueTemplate:
    //         emailQueue.EmailTemplate = overdueTemplate;
    //         break;
    //       case Report reportTemplate:
    //         emailQueue.EmailTemplate = reportTemplate;
    //         break;
    //       case User userTemplate:
    //         emailQueue.EmailTemplate = userTemplate;
    //         break;
    //     }
    //   }
    // }

    return emailQueues;
  }

  public async Task<EmailQueue> GetByIdAsync(int id)
  {
    // return await _context.EmailQueues
    //   .Include(eq => eq.EmailTemplate)
    //   .FirstOrDefaultAsync(eq => eq.EmailQueueId == id);
    var emailQueue = await _context.EmailQueues
        .Include(eq => eq.EmailTemplate)
        .FirstOrDefaultAsync(eq => eq.EmailQueueId == id);

    // if (emailQueue != null && emailQueue.EmailTemplate != null)
    // {
    //   switch (emailQueue.EmailTemplate)
    //   {
    //     case Login loginTemplate:
    //       emailQueue.EmailTemplate = loginTemplate;
    //       break;
    //     case Overdue overdueTemplate:
    //       emailQueue.EmailTemplate = overdueTemplate;
    //       break;
    //     case Report reportTemplate:
    //       emailQueue.EmailTemplate = reportTemplate;
    //       break;
    //     case User userTemplate:
    //       emailQueue.EmailTemplate = userTemplate;
    //       break;
    //   }
    // }

    return emailQueue;
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
