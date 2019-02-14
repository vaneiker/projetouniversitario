using CollectorsModule.dal.GlobalDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Base
{
    public class GlobalRepository : AtlanRepository, IDisposable
    {
        protected GlobalEntities globalModel;

        public GlobalRepository(GlobalEntities globalEntities)
        {
            if(globalEntities != null)
                this.globalModel = globalEntities;
        }
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    globalModel.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
