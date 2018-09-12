using System;
using DATA.UnderWriting.Data;

namespace DATA.UnderWriting.Repositories.Base
{
    public class IllusDataRepository : IDisposable
    {
        protected IllusDataEntityDataModel illusDataModel;

        public IllusDataRepository(IllusDataEntityDataModel illusDataModel)
        {
            this.illusDataModel = illusDataModel;
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
