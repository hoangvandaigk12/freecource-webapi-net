using MyWebApilApp.Data;

namespace MyWebApilApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreContext _context;
        private bool _disposed;
        private Dictionary<string, object> _repositoties;

        public UnitOfWork(BookStoreContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositoties == null)
            {
                _repositoties = new Dictionary<string, object>();
            }
            var type = typeof(T).Name;
            if (!_repositoties.ContainsKey(type))
            {
                var respositoryInstance = new GenericRepository<T>(_context);
                _repositoties.Add(type, respositoryInstance);
            }
            return (IGenericRepository<T>)_repositoties[type];
        }
    }
}
