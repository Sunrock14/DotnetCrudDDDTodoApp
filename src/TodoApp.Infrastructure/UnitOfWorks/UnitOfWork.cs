namespace TodoApp.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly TodoContext _context;

    private CategoryRepository _categoryRepository;
    private TaskRepository _taskRepository;
    private UserRepository _userRepository;

    public UnitOfWork(TodoContext context)
    {
        _context = context;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_context);
    public ITaskRepository Tasks => _taskRepository ??= new TaskRepository(_context);
    public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
