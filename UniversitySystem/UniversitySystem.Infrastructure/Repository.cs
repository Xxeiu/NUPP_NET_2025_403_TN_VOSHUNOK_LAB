using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace UniversitySystem.Infrastructure
{
    // Обобщенная реализация репозитория, использующая DbContext
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UniversitySystemContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(UniversitySystemContext context)
        {
            _context = context;
            // _dbSet позволяет работать с конкретной таблицей, указанной в T
            _dbSet = _context.Set<T>(); 
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id); 
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // AsNoTracking() для повышения производительности при чтении
            return await _dbSet.AsNoTracking().ToListAsync(); 
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync(); // Сохранение изменений в БД
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
