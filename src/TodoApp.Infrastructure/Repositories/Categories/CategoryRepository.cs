namespace TodoApp.Infrastructure.Repositories.Categories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
}
