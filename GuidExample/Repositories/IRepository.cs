namespace GuidExample.Repositories
{
    public interface IRepository<T>
    {
        public T GetById(Guid id);
        public IQueryable<T> GetAll();
        public int Add(T entity);
    }
}
