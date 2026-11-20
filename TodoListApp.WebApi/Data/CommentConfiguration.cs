using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.WebApi.Entities;

namespace TodoListApp.WebApi.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Text).IsRequired().HasMaxLength(1000);
        builder.Property(c => c.AuthorId).IsRequired().HasMaxLength(450);

        builder.HasData(
            new Comment { Id = 1, Text = "Started working on it", CreatedDate = new DateTime(2026, 11, 2, 9, 30, 0, DateTimeKind.Utc), AuthorId = "user-1", TodoTaskId = 1 },
            new Comment { Id = 2, Text = "Need data from analytics", CreatedDate = new DateTime(2026, 11, 3, 11, 0, 0, DateTimeKind.Utc), AuthorId = "user-2", TodoTaskId = 1 },
            new Comment { Id = 3, Text = "Done, everything bought", CreatedDate = new DateTime(2026, 11, 3, 19, 0, 0, DateTimeKind.Utc), AuthorId = "user-1", TodoTaskId = 3 });
    }
}
