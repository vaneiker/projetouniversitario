using KSI.Cobranza.DataLayer.Interfaces;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class ContactPhoneRepository : BaseRepository, IBaseRepository<ContactPhone>, IDBOperation<ContactPhone>
    {
        public ContactPhoneRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<ContactPhone> GetAll(long? entityId = null)
        {
            IEnumerable<ContactPhone> Result;
            var temp = base._dbContext.SP_GET_CONTACT_PHONE(entityId);
            Result = temp.Select(r => new ContactPhone
            {
                relatedContactId = r.relatedContactId,
                contactPhoneId = r.contactPhoneId,
                AreaCode = r.AreaCode,
                Phone = r.Phone,
                PhoneType = r.PhoneType,
                Comments = r.Comments,
                IsPrimary = r.IsPrimary,
                CountryName = r.CountryName

            })
            .ToArray();

            return
                Result;
        }

        public ContactPhone FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Add(ContactPhone entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Delete(ContactPhone entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Edit(ContactPhone entity)
        {
            var temp = base._dbContext.SP_SET_CONTACT_PHONES(entity.contactPhoneId,
                                                            entity.relatedContactId,
                                                            entity.CountryID,
                                                            entity.AreaCode,
                                                            entity.Phone,
                                                            entity.PhoneType,
                                                            entity.Comments,
                                                            entity.IsPrimary,
                                                            entity.isActive,
                                                            entity.userId
                                                            )
                                                            .ToArray();


            return
                   temp.Select(r => new ResultRepository
                   {
                       Action = r.Action,
                       entityId = r.contactPhoneId
                   }).
                   FirstOrDefault();

        }
    }
}
