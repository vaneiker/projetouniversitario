using System;
using System.Collections.Generic;
using WEB.ConfirmationCall.Common;
using WEB.ConfirmationCall.Models;
using WEB.ConfirmationCall.Repositories;

namespace WEB.ConfirmationCall.Managers
{
    public class TaskManager
    {
        private TaskRepository _taskRepository;

        public TaskManager()
        {
            _taskRepository = SingletonUnitOfWork.Instance.TaskRepository;
        }

        public virtual int Count()
        {
            return
                _taskRepository.Count();
        }

        public virtual Task Get(int CorpId, int ContactId, int CallMeetingId)
        {
            return
                _taskRepository.Get(CorpId, ContactId, CallMeetingId);
        }

        public virtual IEnumerable<Task> Get()
        {
            return
                _taskRepository.Get();
        }

        public virtual IEnumerable<Task> Get(int CorpId, int ContactId, DateTime Date)
        {
            return
                _taskRepository.Get(CorpId, ContactId, Date);
        }

        public virtual Task Post(Task Task)
        {
            return
                _taskRepository.Post(Task);
        }
        public virtual Task Put(Task Task)
        {
            return
                _taskRepository.Put(Task);
        }

        public virtual bool Delete(Task Task)
        {
            return
                _taskRepository.Delete(Task);
        }
    }
}
