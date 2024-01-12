using Test.Task.Service.Domain.Enums;

namespace Test.Task.Service.Domain.Entities;

public sealed class Task
{
    public Guid Id { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }
    
    public TaskStatusEnum Status { get; private set; }
    
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

    public void SetStatus(TaskStatusEnum status)
    {
        if (Status != status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}