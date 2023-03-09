using System.Linq.Expressions;
using e_Tickets.Models;

namespace e_Tickets.Data.Services
{
    public interface IRepository<T> where T : class, new()
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        T Update(T newentity);
        void Delete(int id);
        T Find(Expression<Func<T, bool>> kosul);
		//List<T> Search(T Filter);
	}
}
