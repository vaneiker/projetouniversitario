using System;
using WEB.ConfirmationCall.Data;
using WEB.ConfirmationCall.Repositories;

namespace WEB.ConfirmationCall.Common
{
    public sealed class SingletonUnitOfWork : IDisposable
    {
        #region Private Variables
        private readonly Dev_GlobalEntities globalModel;
        private static readonly SingletonUnitOfWork singletonInstance;
        private bool disposed;
        private TaskRepository _taskRepository;
        #endregion
        #region Public Properties
        public static SingletonUnitOfWork Instance
        {
            get
            {
                return 
                    singletonInstance;
            }
        }

        public TaskRepository TaskRepository
        {
            get
            {
                if (this._taskRepository == null)
                {
                    this._taskRepository = new TaskRepository(globalModel);
                }
                return
                    _taskRepository;
            }
        }
        #endregion
        #region Private Methods
        static SingletonUnitOfWork()
        {
            singletonInstance = new SingletonUnitOfWork();
        } 
        private SingletonUnitOfWork()
        {
            globalModel = new Dev_GlobalEntities();
            disposed = false;
        }       
        private void Dispose(bool disposing)
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
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
