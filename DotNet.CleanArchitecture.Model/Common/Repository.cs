using DotNet.CleanArchitecture.Model.Entity.Common;
using DotNet.CleanArchitecture.Model.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.Model.Common
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class, IAudit
    {
        private readonly AppDbContext _Context;

        protected Repository(AppDbContext context)
        {
            _Context = context;
        }

        protected abstract IQueryable<T> GetQuery();

        public void Create(K id, T entity)
        {
            try
            {
                if (id == null)
                {
                    entity.CreationDate = DateTime.Now;
                    entity.ModificationDate = DateTime.Now;
                    _Context.Set<T>().Add(entity);
                    _Context.SaveChanges();
                }
                else
                {
                    T obj = Read(id);
                    if (obj == null)
                    {
                        entity.CreationDate = DateTime.Now;
                        entity.ModificationDate = DateTime.Now;
                        _Context.Set<T>().Add(entity);
                        _Context.SaveChanges();
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

        public T Read(K id)
        {
            try
            {
                var entity = _Context.Set<T>().Find(id);
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

        public List<T> ReadAll()
        {
            try
            {
                return GetQuery().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(K id, T entity)
        {
            T obj = Read(id);
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
                    _Context.SaveChanges();
                }
                else
                {
                    throw new NonEqualObjectException();
                }
            }
        }

        public void Delete(K id)
        {
            try
            {
                T obj = Read(id);
                if (obj == null)
                {
                    throw new NonObjectFoundException();
                }
                else
                {
                    _Context.Set<T>().Remove(obj);
                    _Context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}