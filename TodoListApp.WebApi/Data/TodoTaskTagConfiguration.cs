using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.WebApi.Entities;

namespace TodoListApp.WebApi.Data.Configurations;

public class TodoTaskTagConfiguration : IEntityTypeConfiguration<TodoTaskTag>
{
    public void Configure(EntityTypeBuilder<TodoTaskTag> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(tt => new { tt.TodoTaskId, tt.TagId });

        builder.HasOne(tt => tt.Tag)
            .WithMany(t => t.TaskTags)
            .HasForeignKey(tt => tt.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new TodoTaskTag { TodoTaskId = 1, TagId = 1 },
            new TodoTaskTag { TodoTaskId = 1, TagId = 2 },
            new TodoTaskTag { TodoTaskId = 2, TagId = 2 },
            new TodoTaskTag { TodoTaskId = 3, TagId = 3 });
    }
}
