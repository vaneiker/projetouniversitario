using STL.CALLBACK.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entities;

namespace STL.CALLBACK.Logic
{
    public class CallBackManager: BaseManager
    {
        private readonly CallBackRepository callBackRepository;

        public CallBackManager()
        {
            callBackRepository = new CallBackRepository();
        }

        public int SetCallBack(Callback parameter)
        {
            return
                callBackRepository.SetCallBack(parameter);
        }
    }
}
