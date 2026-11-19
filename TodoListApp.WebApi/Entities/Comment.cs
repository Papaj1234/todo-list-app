namespace TodoListApp.WebApi.Entities;

public class Comment
{
    public int Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public string AuthorId { get; set; } = string.Empty;

    public int TodoTaskId { get; set; }

    public TodoTask TodoTask { get; set; } = null!;
}
