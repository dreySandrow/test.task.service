using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Task.Service.Persistence.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.ToTable("Tasks");
        
        builder.HasKey(e => e.Id)
            .HasName("PK_TaskId");
        
        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();
    }
}