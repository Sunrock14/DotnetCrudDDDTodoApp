namespace TodoApp.Infrastructure.Repositories.Users;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}
