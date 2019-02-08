using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallRex;
using CallRex.Proxy.CallRexReference;

namespace WebServices.CallRex
{
    public class CallRexProxy
    {
        ClientServiceClient proxy;

        public CallRexProxy()
        {
            proxy = new ClientServiceClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<RecordedCallContainer> GetRecordedCallsByUserid(Guid userId, DateTime date)
        {             
            var beginDate = date.Date;
            var endDate = date.Date.AddHours(23.9999);

            return this.GetRecordedCallsByUserid(userId, beginDate, endDate);
        }

        /// <summary>
        /// Obtiene las llamadas grabadas de un usuario en especifico.
        /// </summary>
        /// <param name="userId">Id del usuario.</param>
        /// <param name="beginDate">Fecha Inicial.</param>
        /// <param name="endDate">Fecha Final.</param>
        /// <returns></returns>
        public List<RecordedCallContainer> GetRecordedCallsByUserid(Guid userId, DateTime beginDate, DateTime endDate)
        {
            List<RecordedCallContainer> result;

            try
            {

                result = proxy.GetRecordedCalls(new List<Guid> { userId }.ToArray(),
                                                beginDate,
                                                endDate,
                                                0,
                                                999999,
                                                CallDirection.Both,
                                                null,
                                                null,
                                                null,
                                                new Guid(),
                                                "").ToList();
            }
            catch
            {
                result = new List<RecordedCallContainer>();
            }

            return result;
        }
    }
}
