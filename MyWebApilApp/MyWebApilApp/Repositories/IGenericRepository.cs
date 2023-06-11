using MyWebApilApp.Data;
using System.Linq.Expressions;

namespace MyWebApilApp.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IQueryable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<int> Add(T entity);
        Task AddRange(IQueryable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IQueryable<T> entities);
    }
}
