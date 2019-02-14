using System;
using CollectorsModule.dal.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.AtlanDB;

namespace CollectorsModule.dal.Singleton
{
    public sealed class Singleton : IDisposable
    {
        private static volatile Singleton _instance;
        private static object _syncRoot = new Object();
        private static volatile UnitOfWork.UnitOfWork _unitOfWork;

        private static object _syncRootGP = new Object();
        private static volatile UnitOfWork.UnitOfWorkGP _unitOfWorkGP;

        private bool disposed;

        public UnitOfWork.UnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    lock (_syncRoot)
                    {
                        if (_unitOfWork == null)
                            _unitOfWork = new UnitOfWork.UnitOfWork(new GlobalEntities());
                    }
                }
                return _unitOfWork;
            }
        }

        public UnitOfWork.UnitOfWorkGP UnitOfWorkGP
        {
            get
            {
                if (_unitOfWorkGP == null)
                {
                    lock (_syncRootGP)
                    {
                        if (_unitOfWorkGP == null)
                            _unitOfWorkGP = new UnitOfWork.UnitOfWorkGP(new ATLANEntities());
                    }
                }
                return _unitOfWorkGP;
            }
        }

        private Singleton()
        {
            disposed = false;
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
                
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                    _unitOfWorkGP.Dispose();
                }
            }

            this.disposed = true;
        }
        
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
