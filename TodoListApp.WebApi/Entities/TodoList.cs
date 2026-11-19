namespace TodoListApp.WebApi.Entities;

public class TodoList
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string OwnerId { get; set; } = string.Empty;

    public ICollection<TodoTask> Tasks { get; } = new List<TodoTask>();

    public ICollection<TodoListShare> Shares { get; } = new List<TodoListShare>();
}
