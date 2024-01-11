using Test.Task.Service.Domain.Enums;

namespace Test.Task.Service.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public TaskStatusEnum Status { get; set; }
}