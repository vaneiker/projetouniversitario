using CollectorsModule.dal.GlobalDB;
using CollectorsModule.dal.Implementations;
using CollectorsModule.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private GlobalEntities _globalModel;
        private IClientSearchRepository _clientSearchRepository;
        private IPaymentsRepository _paymentsRepository;
        private IProviderServicesRepository _providerServicesRepository;
        private IUtilitiesRepository _utilitiesRepository;
        private static object _syncRoot = new Object();
        private bool disposed;

        public UnitOfWork()
        {
            _globalModel = new GlobalEntities();
            disposed = false;
        }

        public UnitOfWork(GlobalEntities globalModel)
        {
            _globalModel = globalModel;
            disposed = false;
        }

        public IClientSearchRepository ClientSearchRepository
        {
            get
            {
                if (_clientSearchRepository == null)
                {
                    lock (_syncRoot)
                    {
                        if (_clientSearchRepository == null)
                            _clientSearchRepository = new ClientSearchRepository(_globalModel);
                    }
                }
                return _clientSearchRepository;
            }
        }

        public IPaymentsRepository PaymentsRepository
        {
            get
            {
                if (_paymentsRepository == null)
                {
                    lock (_syncRoot)
                    {
                        if (_paymentsRepository == null)
                            _paymentsRepository = new PaymentsRepository(_globalModel);
                    }
                }
                return _paymentsRepository;
            }
        }

        public IProviderServicesRepository ProviderServicesRepository
        {
            get
            {
                if (_providerServicesRepository == null)
                {
                    lock (_syncRoot)
                    {
                        if (_providerServicesRepository == null)
                            _providerServicesRepository = new ProviderServicesRepository(_globalModel);
                    }
                }
                return _providerServicesRepository;
            }
        }

        public IUtilitiesRepository UtilitiesRepository
        {
            get
            {
                if (_utilitiesRepository == null)
                {
                    lock (_syncRoot)
                    {
                        if (_utilitiesRepository == null)
                            _utilitiesRepository = new UtilitiesRepository(_globalModel);
                    }
                }
                return _utilitiesRepository;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _clientSearchRepository.Dispose();
                    _paymentsRepository.Dispose();
                    _providerServicesRepository.Dispose();
                    _utilitiesRepository.Dispose();
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
