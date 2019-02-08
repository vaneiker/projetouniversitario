using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSI.Cobranza.DataLayer.Repositories;

namespace KSI.Cobranza.DataLayer
{
    public sealed class SingletonUnitOfWork : IDisposable
    {
        private DbContext _dbContext;
        private CustomerRepository _customerRepository;
        private ContactPhoneRepository _contactPhoneRepository;
        private ContactEmailAdressRepository _contactEmailAdressRepository;
        private LoanRepository _loanRepository;
        private BaseRepository _baseRepository;

        private static readonly SingletonUnitOfWork singletonInstance;
        
        public static SingletonUnitOfWork Instance
        {
            get
            {
                return
                    singletonInstance;
            }
        }

        #region Repositories

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                {
                    this._customerRepository = new CustomerRepository(_dbContext);
                }
                return
                    _customerRepository;
            }
        }

        public ContactPhoneRepository ContactPhoneRepository
        {
            get
            {
                if (this._contactPhoneRepository == null)
                {
                    this._contactPhoneRepository = new ContactPhoneRepository(_dbContext);
                }
                return
                    _contactPhoneRepository;
            }
        }

        public ContactEmailAdressRepository ContactEmailAdressRepository
        {
            get
            {
                if (this._contactEmailAdressRepository == null)
                {
                    this._contactEmailAdressRepository = new ContactEmailAdressRepository(_dbContext);
                }
                return
                    _contactEmailAdressRepository;
            }
        }

        public LoanRepository LoanRepository
        {
            get
            {
                if (this._loanRepository == null)
                {
                    this._loanRepository = new LoanRepository(_dbContext);
                }
                return
                    _loanRepository;
            }
        }

        public BaseRepository BaseRepository
        {
            get
            {
                if (this._baseRepository == null)
                {
                    this._baseRepository = new BaseRepository(_dbContext);
                }
                return
                    _baseRepository;
            }
        }
        #endregion


        /// <summary>
        /// Static Constructor
        /// </summary>
        static SingletonUnitOfWork()
        {
            singletonInstance = new SingletonUnitOfWork();
        }

        private SingletonUnitOfWork()
        {
            _dbContext = new EFModel.LoansEntities();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
