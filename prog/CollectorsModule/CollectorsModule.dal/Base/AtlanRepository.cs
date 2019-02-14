using CollectorsModule.dal.AtlanDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.Base
{
    public class AtlanRepository
    {
        protected ATLANEntities atlanModel;

        public void initAtlanRepository(ATLANEntities atlanEntities)
        {
            this.atlanModel = atlanEntities;
        }
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    atlanModel.Dispose();
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
