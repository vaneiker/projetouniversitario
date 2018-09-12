using System;
using WEB.ConfirmationCall.Data;

namespace WEB.ConfirmationCall.Repositories.Global
{
    public class GlobalRepository : IDisposable
    {
        protected Dev_GlobalEntities globalModel;

        public GlobalRepository(Dev_GlobalEntities globalModel) 
        {
            this.globalModel = globalModel;
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
