using CollectorsModule.dal.AtlanDB;
using CollectorsModule.dal.Implementations;
using CollectorsModule.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.dal.UnitOfWork
{
    public class UnitOfWorkGP : IDisposable
    {
        private ATLANEntities _atlanModel;
        private IClientSearchRepository _clientSearchRepositoryGP;
        private IPaymentsRepository _paymentsRepositoryGP;
        private IProviderServicesRepository _providerServicesRepositoryGP;
        private IUtilitiesRepository _utilitiesRepositoryGP;
        private static object _syncRoot = new Object();
        private bool disposed;

        public UnitOfWorkGP()
        {
            _atlanModel = new ATLANEntities();
            disposed = false;
        }

        public UnitOfWorkGP(ATLANEntities atlanModel)
        {
            _atlanModel = atlanModel;
            disposed = false;
        }

        public IClientSearchRepository ClientSearchRepositoryGP
        {
            get
            {
                if (_clientSearchRepositoryGP == null)
                {
                    lock (_syncRoot)
                    {
                        if (_clientSearchRepositoryGP == null)
                            _clientSearchRepositoryGP = new ClientSearchRepository(_atlanModel);
                    }
                }
                return _clientSearchRepositoryGP;
            }
        }

        public IPaymentsRepository PaymentsRepositoryGP
        {
            get
            {
                if (_paymentsRepositoryGP == null)
                {
                    lock (_syncRoot)
                    {
                        if (_paymentsRepositoryGP == null)
                            _paymentsRepositoryGP = new PaymentsRepository(_atlanModel);
                    }
                }
                return _paymentsRepositoryGP;
            }
        }

        public IProviderServicesRepository ProviderServicesRepositoryGP
        {
            get
            {
                if (_providerServicesRepositoryGP == null)
                {
                    lock (_syncRoot)
                    {
                        if (_providerServicesRepositoryGP == null)
                            _providerServicesRepositoryGP = new ProviderServicesRepository(_atlanModel);
                    }
                }
                return _providerServicesRepositoryGP;
            }
        }

        public IUtilitiesRepository UtilitiesRepositoryGP
        {
            get
            {
                if (_utilitiesRepositoryGP == null)
                {
                    lock (_syncRoot)
                    {
                        if (_utilitiesRepositoryGP == null)
                            _utilitiesRepositoryGP = new UtilitiesRepository(_atlanModel);
                    }
                }
                return _utilitiesRepositoryGP;
            }
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _clientSearchRepositoryGP.Dispose();
                    _paymentsRepositoryGP.Dispose();
                    _providerServicesRepositoryGP.Dispose();
                    _utilitiesRepositoryGP.Dispose();

                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            _atlanModel.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
