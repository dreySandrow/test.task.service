using Microsoft.EntityFrameworkCore;

namespace Test.Task.Service.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Domain.Entities.Task> Tasks { get; set; }
}