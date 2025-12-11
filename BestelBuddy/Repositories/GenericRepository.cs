using BestelBuddy.Data;
using Microsoft.EntityFrameworkCore;

namespace BestelBuddy.Repositories
{
	public class GenericRepository<T> : IRepository<T> where T : class
	{
		private readonly BestelBuddyContext _context;
		private readonly DbSet<T> _dbSet;

		public GenericRepository(BestelBuddyContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public void Add(T entity) => _dbSet.Add(entity);
		public IEnumerable<T> GetAll() => _dbSet.ToList();
		public T? GetById(int id) => _dbSet.Find(id);
		public void Save() => _context.SaveChanges();
	}
}