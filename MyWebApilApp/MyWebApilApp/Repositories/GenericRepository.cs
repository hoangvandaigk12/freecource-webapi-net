using MyWebApilApp.Data;
using System.Linq.Expressions;

namespace MyWebApilApp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BookStoreContext _context;

        public GenericRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity.Id;
        }

        public async Task AddRange(IQueryable<T> entities)
        {
            _context.Set<T>().AddRange();
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            return _context.Set<T>().Where(e => e.Status != "Inactive");
        }

        public async Task<T> GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task RemoveRange(IQueryable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
