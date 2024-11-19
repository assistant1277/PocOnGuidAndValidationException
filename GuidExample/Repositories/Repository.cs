using GuidExample.Data;
using Microsoft.EntityFrameworkCore;

namespace GuidExample.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }
    }
}