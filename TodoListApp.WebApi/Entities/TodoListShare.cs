namespace TodoListApp.WebApi.Entities;

public class TodoListShare
{
    public int TodoListId { get; set; }

    public TodoList TodoList { get; set; } = null!;

    public string UserId { get; set; } = string.Empty;

    public TodoListRole Role { get; set; }
}
