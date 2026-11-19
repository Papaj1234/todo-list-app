namespace TodoListApp.WebApi.Entities;

public class TodoTask
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DueDate { get; set; }

    public TodoTaskStatus Status { get; set; }

    public string AssigneeId { get; set; } = string.Empty;

    public int TodoListId { get; set; }

    public TodoList TodoList { get; set; } = null!;

    public ICollection<Comment> Comments { get; } = new List<Comment>();

    public ICollection<TodoTaskTag> TaskTags { get; } = new List<TodoTaskTag>();
}
