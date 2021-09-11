using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTec.Gbso.Bll.Interfaces;
using PruebaTec.Gbso.Dal;

namespace PruebaTec.Gbso.Bll
{
	public class BaseService<T> : IBaseService<T> where T : class
	{
		private readonly RootDbContext rootDbContext;
		private readonly IMapper mapper;

		public BaseService(RootDbContext rootDbContext, IMapper mapper)
		{
			this.rootDbContext = rootDbContext;
			this.mapper = mapper;
		}

		public async Task<T> AddAsync(T @object)
		{
			await rootDbContext.AddAsync<T>(@object);
			await rootDbContext.SaveChangesAsync();
			return @object;
		}

		public async Task AddRangeAsync(IEnumerable<T> objectList)
		{
			await rootDbContext.Set<T>().AddRangeAsync(objectList);
			await rootDbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			var @object = await rootDbContext.Set<T>().ToArrayAsync();
			return @object;
		}

		public async Task<T> FindAsync(params object[] ids)
		{
			var @object = await rootDbContext.FindAsync<T>(ids);
			return @object;
		}

		public async Task UpdateAsync(T @object)
		{
			rootDbContext.Update<T>(@object);
			await rootDbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(T @object, params object[] ids)
		{
			var entity = rootDbContext.Find<T>(ids);
			var entry = rootDbContext.Entry(entity);
			mapper.Map(entity, @object);
			entry.CurrentValues.SetValues(@object);
			rootDbContext.Update<T>(entity);
			await rootDbContext.SaveChangesAsync();
		}

		public async Task RemoveAsync(params object[] ids)
		{
			var @object = await FindAsync(ids);
			if (@object != null)
			{
				rootDbContext.Remove<T>(@object);
				await rootDbContext.SaveChangesAsync();
			}
		}

		public async Task RemoveAsync(T @object)
		{
			rootDbContext.Update<T>(@object);
			await rootDbContext.SaveChangesAsync();
		}
	}
}
