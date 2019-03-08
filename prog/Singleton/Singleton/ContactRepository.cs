using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ContactRepository<T> : BaseRepository<Contact>, IRepository<Contact>
    {
        public ContactRepository() : base(Singleton.Instance.oContext) { }


        IEnumerable<Contact> IRepository<Contact>.GetAll()
        {
            return base.GetAll();
        }

        IEnumerable<Contact> IRepository<Contact>.Find(System.Linq.Expressions.Expression<Func<Contact, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        void IRepository<Contact>.Add(Contact entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Contact>.Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Contact>.Edit(Contact entity)
        {
            throw new NotImplementedException();
        }

        void IRepository<Contact>.Save()
        {
            throw new NotImplementedException();
        }
    }
}
