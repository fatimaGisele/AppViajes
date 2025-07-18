using BlogViajes.Data;
using BlogViajes.Models;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext context;
        internal DbSet<T> DbSet;
        public Repository(ApplicationDbContext _context)
            {
            this.context = _context;
            this.DbSet = _context.Set<T>();
            }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(int id)
        {
            T entityToRemove = DbSet.Find(id);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> q = DbSet;
            
            if(filter != null)
            {
                q = q.Where(filter);
            }

            if(includeProperties != null)
            {
                foreach (var i in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    q = q.Include(i);
                }
            }

            if(orderBy != null)
            {
                return orderBy(q).ToList();//se ordenan los resultados de la consultan y se presentan en una lista 
            }
            
            return q.ToList();//se transforma la consulta en una lista
        }

        public T GetById(int id)
        {
                return DbSet.Find(id);  
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> q = DbSet;

            if (filter != null)
            {
                q = q.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var i in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    q = q.Include(i);
                }
            }
            return q.FirstOrDefault();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
