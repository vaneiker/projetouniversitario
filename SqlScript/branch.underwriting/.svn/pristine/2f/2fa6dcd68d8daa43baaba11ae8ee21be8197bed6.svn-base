using System;
using DATA.UnderWriting.Data;

namespace DATA.UnderWriting.Repositories.Base
{
    public class GlobalRepository : IDisposable
    {
        protected GlobalEntityDataModel globalModel;
        protected GlobalEntities globalModelExtended;
        protected string globalconexionStringForAdo { get; set; }

        public GlobalRepository(GlobalEntityDataModel globalModel, GlobalEntities globalModelExtended, string globalconexionStringForAdo = "")
        {
            this.globalModel = globalModel;
            this.globalModelExtended = globalModelExtended;
            this.globalconexionStringForAdo = globalconexionStringForAdo;
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
