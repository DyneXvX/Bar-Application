using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BarApplication.DataAccess.Data;
using BarApplication.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BarApplication.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (orderBy != null) return orderBy(query).ToList();

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null) query = query.Where(filter);

            if (includeProperties != null)
                foreach (var includeProp in includeProperties.Split(new[] {','},
                    StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(int id)
        {
            var entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}