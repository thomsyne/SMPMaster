using SchoolWeb.Data;
using SchoolWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private smpEntities2 _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new smpEntities2();
            table = _context.Set<T>();
        }
        public GenericRepository(smpEntities2 _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }

        ////public static IQueryable<TEntity> IncludeQry<TEntity>(this IDbSet<TEntity> dbSet,
        ////                                     params Expression<Func<TEntity, object>>[] includes)
        ////                                     where TEntity : class
        ////{
        ////    IQueryable<TEntity> query = null;
        ////    foreach (var include in includes)
        ////    {
        ////        query = dbSet.Include(include);
        ////    }

        ////    return query == null ? dbSet : query;
        ////}

        public IEnumerable<T> Query()
        {
            IQueryable<T> query = table; return query.ToList();
        }

        public IEnumerable<T> AllEager(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {

                query = query.Where(filter);

            }
            return query;
        }
        public T Find(object id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> LoadViaStockProc(string procName, params object[] param) // SqlParameter param)// params object[] param)
        {

        
            IEnumerable<T> res = _context.Database.SqlQuery<T>(procName);
            return res;
            
        }

    }
}
