namespace TodoApp.Infrastructure.Contexts;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options): base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TodoTask> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);
    }
}