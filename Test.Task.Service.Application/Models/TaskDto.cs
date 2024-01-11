using Test.Task.Service.Domain.Enums;

namespace Test.Task.Service.Application.Models;

public class TaskDto
{
    public Guid Id { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public TaskStatusEnum Status { get; set; }
}