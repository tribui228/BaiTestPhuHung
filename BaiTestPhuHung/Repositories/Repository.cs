using BaiTestPhuHung.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaiTestPhuHung.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }



        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> CheckUserNameExistAsync(T entity)
        {
            var propInfo = typeof(T).GetProperty("UserName");
            if (propInfo == null)
                throw new ArgumentException("Entity must have a UserName property");

            var userName = (string)propInfo.GetValue(entity);
            return await _dbSet.AnyAsync(e => EF.Property<string>(e, "UserName") == userName);
        }

        public async Task<bool> CheckEmailExistAsync(T entity)
        {
            var propInfo = typeof(T).GetProperty("Email");
            if (propInfo == null)
                throw new ArgumentException("Entity must have an Email property");

            var email = (string)propInfo.GetValue(entity);
            return await _dbSet.AnyAsync(e => EF.Property<string>(e, "Email") == email);
        }
    }
}
