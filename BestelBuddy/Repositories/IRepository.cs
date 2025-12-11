namespace BestelBuddy.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Save();
    }
}