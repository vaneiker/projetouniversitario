using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.LogicLayer.Interface
{
    public interface IBaseLogic<T> where T : class
    {
        ResultLogic<T> GetAll(long? entityId = null);
        BaseResultLogic<T> FindById(long? Id);
        Result Add(T entity);
        Result Delete(T entity);
        Result Edit(T entity);        
    }
}
