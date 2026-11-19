using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.WebApi.Entities;

namespace TodoListApp.WebApi.Data.Configurations;

public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
{
    public void Configure(EntityTypeBuilder<TodoTask> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).IsRequired().HasMaxLength(100);
        builder.Property(t => t.Description).HasMaxLength(1000);
        builder.Property(t => t.AssigneeId).IsRequired().HasMaxLength(450);
        builder.Property(t => t.Status).HasConversion<string>().HasMaxLength(20);

        builder.HasMany(t => t.Comments)
            .WithOne(c => c.TodoTask)
            .HasForeignKey(c => c.TodoTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.TaskTags)
            .WithOne(tt => tt.TodoTask)
            .HasForeignKey(tt => tt.TodoTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new TodoTask
            {
                Id = 1,
                Title = "Prepare sprint report",
                Description = "Summarize completed stories",
                CreatedDate = new DateTime(2026, 11, 1, 9, 0, 0, DateTimeKind.Utc),
                DueDate = new DateTime(2026, 11, 20, 18, 0, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.InProgress,
                AssigneeId = "user-1",
                TodoListId = 1,
            },
            new TodoTask
            {
                Id = 2,
                Title = "Code review",
                Description = "Review pull requests from the team",
                CreatedDate = new DateTime(2026, 11, 2, 10, 0, 0, DateTimeKind.Utc),
                DueDate = new DateTime(2026, 11, 15, 18, 0, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.NotStarted,
                AssigneeId = "user-2",
                TodoListId = 1,
            },
            new TodoTask
            {
                Id = 3,
                Title = "Buy groceries",
                Description = "Milk, bread, eggs",
                CreatedDate = new DateTime(2026, 11, 3, 8, 0, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.Completed,
                AssigneeId = "user-1",
                TodoListId = 2,
            },
            new TodoTask
            {
                Id = 4,
                Title = "Finish OS lab",
                Description = "Lab work on process memory",
                CreatedDate = new DateTime(2026, 11, 4, 12, 0, 0, DateTimeKind.Utc),
                DueDate = new DateTime(2026, 11, 25, 23, 59, 0, DateTimeKind.Utc),
                Status = TodoTaskStatus.NotStarted,
                AssigneeId = "user-2",
                TodoListId = 3,
            });
    }
}
