using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.ConfirmationCall.Data;
using WEB.ConfirmationCall.Models;
using WEB.ConfirmationCall.Repositories.Global;

namespace WEB.ConfirmationCall.Repositories
{
    public class TaskRepository : GlobalRepository
    {
        public TaskRepository(Dev_GlobalEntities globalModel) : base(globalModel) { }

        private List<Task> Tasks
        {
            get
            {
                if (HttpContext.Current.Cache["Tasks"] == null)
                    HttpContext.Current.Cache["Tasks"] = new List<Task>();

                return HttpContext.Current.Cache["Tasks"] as List<Task>;
            }
            set
            {
                HttpContext.Current.Cache["Tasks"] = value;
            }
        }

        public virtual int Count()
        {
            return Tasks.Count();
        }

        public virtual Task Get(int CorpId, int ContactId, int CallMeetingId)
        {
            return Tasks.Find(t => t.CallMeetingId == CallMeetingId);
        }

        public virtual IEnumerable<Task> Get()
        {
            return Tasks;
        }

        public virtual IEnumerable<Task> Get(int CorpId, int ContactId, DateTime Date)
        {
            IEnumerable<CA_CALL_MEETING_PROCESS> resultset;
            resultset = globalModel.CA_CALL_MEETING_PROCESS.Where(s => s.Corp_Id == CorpId && s.Create_Date == Date);
            return Tasks.Where(t => t.Date == Date);
        }

        public virtual Task Post(Task task)
        {
            //task.Id = Tasks.Max(t => t.Id) + 1;
            var t = Get(task.CorpId, task.ContactId, task.CallMeetingId);
            if (t == null)
            {
                Tasks.Add(task);
            }
            else
            {
                t.Date = task.Date;
                t.TimeHour = task.TimeHour;
                t.TimeMinutes = task.TimeMinutes;
                t.TimePeriod = task.TimePeriod;
                t.RelatedTo = task.RelatedTo;
                t.Note = task.Note;
            }

            return t;
        }

        public virtual Task Put(Task task)
        {
            var t = Get(task.CorpId, task.ContactId, task.CallMeetingId);

            if (t == null)
            {
                throw new Exception(string.Format("Task with id {0} not exists.", task.CallMeetingId));
            }

            t.Date = task.Date;
            t.TimeHour = task.TimeHour;
            t.TimeMinutes = task.TimeMinutes;
            t.TimePeriod = task.TimePeriod;
            t.RelatedTo = task.RelatedTo;
            t.Note = task.Note;
            return t;
        }

        public virtual bool Delete(Task task)
        {
            var t = Get(task.CorpId, task.ContactId, task.CallMeetingId);

            if (t == null)
                return false;

            Tasks.Remove(t);

            return true;
        }
    }
}