using System.Linq.Expressions;

namespace BaiTestPhuHung.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> CheckUserNameExistAsync(T entity);
        Task<bool> CheckEmailExistAsync(T entity);
    }
}
