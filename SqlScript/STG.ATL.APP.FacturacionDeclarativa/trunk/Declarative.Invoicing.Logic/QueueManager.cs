using Declarative.Invoicing.Data.Repository;
using Declarative.Invoicing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Logic
{
    public class QueueManager : BaseManager
    {
        private readonly QueueRepository queueRepository;

        public QueueManager()
        {
            queueRepository = new QueueRepository();
        }

        #region Get

        public IEnumerable<Queue> GetQueue(string policy, DateTime? DateBilling)
        {
            return
                queueRepository.GetQueue(policy, DateBilling);
        }

        public virtual IEnumerable<Queue.Periods> GetPeriods(DateTime? Date)
        {
            return
                queueRepository.GetPeriods(Date);
        }

        public virtual IEnumerable<Queue.Historic> GetHistoric(string policy)
        {
            return
                queueRepository.GetHistoric(policy);
        }

        

        #endregion
    }
}
