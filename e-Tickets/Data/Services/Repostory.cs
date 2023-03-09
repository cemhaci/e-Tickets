using System.Linq.Expressions;
using e_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Data.Services
{
	public class Repostory<T> : IRepository<T> where T : class, new()
	{
		AppDbContext _context;
		DbSet<T> _object;
		public Repostory(AppDbContext context)
		{
			_object=context.Set<T>();
			_context=context;
			
		}
		public void Add(T entity)
		{
			_object.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var getid= GetById(id);
			 _object.Remove(getid);
			_context.SaveChanges();
		}

		public List<T> GetAll()
		{
			var result = _object.ToList();
			return result;
		}

		public T GetById(int id)
		{
			var actorid = _object.Find(id);
			return actorid;
		}

		public T Update(T newentity)
		{
			_object.Update(newentity);
			_context.SaveChanges();
			return newentity;
		}
  //      public List<T> Search(T Filter)
		//{

  //          return _object.Where(x=>x.);
  //      }
    }
}
