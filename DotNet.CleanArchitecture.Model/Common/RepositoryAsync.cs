using DotNet.CleanArchitecture.Model.Entity.Common;
using DotNet.CleanArchitecture.Model.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Common
{
    public abstract class RepositoryAsync<K, T> : IRepositoryAsync<K, T> where T : class, IAudit
    {
        private readonly AppDbContext _Context;

        protected RepositoryAsync(AppDbContext context)
        {
            _Context = context;
        }

        protected abstract IQueryable<T> GetQuery();

        public async Task CreateAsync(K id, T entity)
        {
            try
            {
                if (id == null)
                {
                    entity.CreationDate = DateTime.Now;
                    entity.ModificationDate = DateTime.Now;
                    _Context.Set<T>().Add(entity);
                    await _Context.SaveChangesAsync();
                }
                else
                {
                    T obj = await ReadAsync(id);
                    if (obj == null)
                    {
                        entity.CreationDate = DateTime.Now;
                        entity.ModificationDate = DateTime.Now;
                        _Context.Set<T>().Add(entity);
                        await _Context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new EqualUniqueRowException();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> ReadAsync(K id)
        {
            try
            {
                var entity = await _Context.Set<T>().FindAsync(id);
                if (entity != null)
                {
                    _Context.Entry(entity).State = EntityState.Detached;
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> ReadAllAsync()
        {
            try
            {
                return await GetQuery().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(K id, T entity)
        {
            T obj = await ReadAsync(id);
            if (obj == null)
            {
                throw new NonObjectFoundException();
            }
            else
            {
                if (obj.Equals(entity))
                {
                    entity.ModificationDate = DateTime.Now;
                    _Context.Set<T>().Update(entity);
                    await _Context.SaveChangesAsync();
                }
                else
                {
                    throw new NonEqualObjectException();
                }
            }
        }

        public async Task DeleteAsync(K id)
        {
            try
            {
                T obj = await ReadAsync(id);
                if (obj == null)
                {
                    throw new NonObjectFoundException();
                }
                else
                {
                    _Context.Set<T>().Remove(obj);
                    await _Context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}