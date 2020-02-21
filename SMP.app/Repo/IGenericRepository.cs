using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> AllEager(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
         T Find(object id);

        IEnumerable<T> LoadViaStockProc(string procName, params object[] param);
        IEnumerable<T> Query();

        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
