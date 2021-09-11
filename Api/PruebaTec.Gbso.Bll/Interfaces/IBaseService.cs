using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Bll.Interfaces
{
	public interface IBaseService<T> where T : class
	{
		Task<T> AddAsync(T @object);
		Task AddRangeAsync(IEnumerable<T> objectList);
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> FindAsync(params object[] ids);
		Task UpdateAsync(T @object);
		Task RemoveAsync(params object[] ids);
		Task RemoveAsync(T @object);
		Task UpdateAsync(T @object, params object[] ids);
	}
}
