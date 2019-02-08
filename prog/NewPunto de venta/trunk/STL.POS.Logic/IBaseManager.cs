using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Logic
{
    interface IBaseManager<T>
    {
        IEnumerable<T> GetAll(int Id);
        T Get();
    }
}
