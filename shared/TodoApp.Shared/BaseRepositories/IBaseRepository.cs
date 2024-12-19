using System.Linq.Expressions;
using TodoApp.Shared.BaseRepositories;

namespace Star.Core.BaseRepository;

/// <summary>
///  Generic Repository Base Service
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IBaseRepository<T> where T : class, IEntity, new()
{
    /// <summary>
    /// Tek bir kayıtı getirmek için kullanılır
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    /// <summary>
    /// Tek bir kayıtı getirmek için kullanılır
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    Task<T> GetLastAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> orderBy, params Expression<Func<T, object>>[] includeProperties);
    /// <summary>
    /// Birden fazla kayıtı getirmek için kullanılır
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includeProperties"></param>
    /// <returns></returns>
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties);
    /// <summary>
    /// Bir kayıt eklemek için kullanılır
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> AddAsync(T entity);
    /// <summary>
    /// Birden Fazla kayıt eklemek için kullanılır
    /// </summary>
    /// <param name="entities"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IList<T>> AddRangeAsync(IList<T> entities, CancellationToken cancellationToken = default);
    /// <summary>
    /// Bir kayıtı güncellemek için kullanılır
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<T> UpdateAsync(T entity);
    /// <summary>
    /// Bir kayıtı silmek için kullanılır
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task DeleteAsync(T entity);
    /// <summary>
    /// Bilgisi verilen kayıtın olup olmadığını kontrol eder
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Verilen sorguya göre kaç adet kayıt var onun sayısını getirir
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    /// <summary>
    /// Sorgusu verilen bir kayıtı getirir
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<T> FindAsync(Expression<Func<T, bool>>? predicate = null);
    /// <summary>
    /// Sorgusu verilen birden fazla kayıtı getirir
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IList<T>> FindAllAsync(Expression<Func<T, bool>>? predicate);
    /// <summary>
    /// Kompleks sorgular yazmak için kullanılır
    /// </summary>
    /// <returns></returns>
    IQueryable<T> QueryAsync();
}
