using KSI.Cobranza.DataLayer.Interfaces;
using KSI.Cobranza.EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.DataLayer.Repositories
{
    public class ContactEmailAdressRepository : BaseRepository, IBaseRepository<ContactEmail>, IDBOperation<ContactEmail>
    {
        public ContactEmailAdressRepository(DbContext dbContext)
            : base(dbContext)
        {

        }   

        public IEnumerable<ContactEmail> GetAll(long? entityId = null)
        {
            IEnumerable<ContactEmail> Result;
            var temp = base._dbContext.SP_GET_CONTACT_EMAIL(entityId);
            Result = temp.Select(r => new ContactEmail
            {
                relatedContactId = r.relatedContactId,
                contactEmailId = r.contactEmailId,
                email = r.email,
                emailType = r.emailType,
                comments = r.comments,
                IsPrimary = r.IsPrimary
            })
            .ToArray();

            return
                Result;
        }

        public ContactEmail FindById(long? Id)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Add(ContactEmail entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Delete(ContactEmail entity)
        {
            throw new NotImplementedException();
        }

        public ResultRepository Edit(ContactEmail entity)
        {
            var temp = base._dbContext.SP_SET_CONTACT_EMAIL(entity.contactEmailId,
                                                            entity.relatedContactId,
                                                            entity.email,
                                                            entity.emailType,
                                                            entity.comments,
                                                            entity.IsPrimary,
                                                            entity.isActive,
                                                            entity.userId
                                                            )
                                                            .ToArray();


            return
                   temp.Select(r => new ResultRepository
                   {
                       Action = r.Action,
                       entityId = r.contactEmailId
                   }).
                   FirstOrDefault();
        }
    }
}
