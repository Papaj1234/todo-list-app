using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.WebApi.Entities;

namespace TodoListApp.WebApi.Data.Configurations;

public class TodoListShareConfiguration : IEntityTypeConfiguration<TodoListShare>
{
    public void Configure(EntityTypeBuilder<TodoListShare> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(s => new { s.TodoListId, s.UserId });
        builder.Property(s => s.UserId).IsRequired().HasMaxLength(450);
        builder.Property(s => s.Role).HasConversion<string>().HasMaxLength(20);

        builder.HasData(
            new TodoListShare { TodoListId = 1, UserId = "user-2", Role = TodoListRole.Editor },
            new TodoListShare { TodoListId = 1, UserId = "user-3", Role = TodoListRole.Viewer },
            new TodoListShare { TodoListId = 3, UserId = "user-1", Role = TodoListRole.Viewer });
    }
}
