using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.DataLayer.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(long? entityId = null);
        T FindById(long? Id);
    }

    public interface IDBOperation<T> where T : class
    {
        ResultRepository Add(T entity);
        ResultRepository Delete(T entity);
        ResultRepository Edit(T entity);
    }

    public interface IDeleteAllRecord<T> where T : class
    {
        void Delete(IEnumerable<T> entity);
    }
}
