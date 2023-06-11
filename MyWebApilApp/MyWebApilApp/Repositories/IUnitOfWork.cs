using MyWebApilApp.Data;

namespace MyWebApilApp.Repositories
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Dispose(bool disposing);
        void Commit();
        Task CommitAsync();
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
    }
}
