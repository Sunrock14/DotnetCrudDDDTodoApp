using Microsoft.EntityFrameworkCore;
using Star.Core.BaseRepository;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Repositories.Categories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DbContext context) : base(context)
    {
    }
}
