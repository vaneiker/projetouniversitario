using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.AgentWSProxy
{
    public class QueuesProxy : IQueuesProxy
    {

        private QueuesServices.QueuesClient QueuesClient;
        public QueuesProxy()
        {
            QueuesClient = new QueuesServices.QueuesClient();
        }
        public QueuesServices.FilterQueues FilterQueues()
        {
            return new QueuesServices.FilterQueues();
        }

        public QueuesServices.FilterAnonimus FilterQueuesAnomimus()
        {
            return new QueuesServices.FilterAnonimus();
        }

        public QueuesServices.Queues[] SetQueue(QueuesServices.FilterQueues filterQueues)
        {
            var result = QueuesClient.SP_SET_QUEUES(filterQueues);
            return result;
        }
        public QueuesServices.Queues[] SetQueueAnomimusWithSourceId(QueuesServices.FilterAnonimus filterQueues)
        {
            var result = QueuesClient.SP_SET_QUEUES_ANONIMOUS_WITH_SOURCEID(filterQueues);
            return result;
        }

    }
}
