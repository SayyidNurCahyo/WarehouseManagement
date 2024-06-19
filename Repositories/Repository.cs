using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace WarehouseManagement.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        
        public TEntity Attach(TEntity entity)
        {
            var entry = _context.Set<TEntity>().Attach(entity);
            return entry.Entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity?>> FindAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> criteria)
        {
            var entity = await _context.Set<TEntity>().Where(criteria).ToListAsync();
            if (entity.Count == 0) return null;
            return entity;
        }

        public async Task<List<TEntity?>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await _context.Set<TEntity>().Where(criteria).ToListAsync();
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria)
        {
            // bisa juga pake _context.Set<TEntity>().Where(criteria);
            return await _context.Set<TEntity>().FirstOrDefaultAsync(criteria);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            // sama kayak pake query.Include().Include().FirstOrDefaultAsync()
            return await query.FirstOrDefaultAsync(criteria);
        }

        public async Task<TEntity?> FindByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
            
        }

        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            var entry = await _context.Set<TEntity>().AddAsync(entity);
            return entry.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            Attach(entity);
            _context.Set<TEntity>().Update(entity);
            return entity;
        }
    }
}
