using Microsoft.EntityFrameworkCore;

namespace Test.Task.Service.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    private static readonly SemaphoreSlim semaphoreSlim = new(1); // Initialize with 1 permit

    public DbSet<Domain.Entities.Task> Tasks { get; set; }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        int result;
        
        await semaphoreSlim.WaitAsync(cancellationToken);
        try
        {
            result = await base.SaveChangesAsync(cancellationToken);
        }
        finally
        {
            semaphoreSlim.Release();
        }
        return result;
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new NotImplementedException();
    }
}