using Test.Task.Service.Domain.Enums;

namespace Test.Task.Service.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public TaskStatusEnum Status { get; set; }
    
    private Task()
    {
        
    }

    public static Task Create()
    {
        var task = new Task();
        task.Id = Guid.NewGuid();
        task.UpdatedAt = DateTime.UtcNow;
        task.Status = TaskStatusEnum.Created;
        
        return task;
    }
}