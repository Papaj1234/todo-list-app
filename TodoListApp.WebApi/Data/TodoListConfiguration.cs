using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.WebApi.Entities;

namespace TodoListApp.WebApi.Data.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Title).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Description).HasMaxLength(500);
        builder.Property(l => l.OwnerId).IsRequired().HasMaxLength(450);

        builder.HasMany(l => l.Tasks)
            .WithOne(t => t.TodoList)
            .HasForeignKey(t => t.TodoListId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.Shares)
            .WithOne(s => s.TodoList)
            .HasForeignKey(s => s.TodoListId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new TodoList { Id = 1, Title = "Work", Description = "Tasks related to work projects", OwnerId = "user-1" },
            new TodoList { Id = 2, Title = "Home", Description = "Household chores", OwnerId = "user-1" },
            new TodoList { Id = 3, Title = "Study", Description = "University assignments", OwnerId = "user-2" });
    }
}
