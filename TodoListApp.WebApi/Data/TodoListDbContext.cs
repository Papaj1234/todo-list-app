using Microsoft.EntityFrameworkCore;
using TodoListApp.WebApi.Entities;

namespace TodoListApp.WebApi.Data;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoList> TodoLists => this.Set<TodoList>();

    public DbSet<TodoTask> TodoTasks => this.Set<TodoTask>();

    public DbSet<Tag> Tags => this.Set<Tag>();

    public DbSet<TodoTaskTag> TodoTaskTags => this.Set<TodoTaskTag>();

    public DbSet<Comment> Comments => this.Set<Comment>();

    public DbSet<TodoListShare> TodoListShares => this.Set<TodoListShare>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListDbContext).Assembly);
    }
}
