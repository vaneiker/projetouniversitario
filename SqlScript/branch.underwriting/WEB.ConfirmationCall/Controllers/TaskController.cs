using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEB.ConfirmationCall.Managers;
using WEB.ConfirmationCall.Models;

namespace WEB.ConfirmationCall.Controllers
{
    public class TaskController : ApiController
    {
        private TaskManager _taskRepository = new TaskManager();

        public TaskController()
        {
            if (_taskRepository.Count() == 0)
            {
                _taskRepository.Post(new Task { CorpId = 1, ContactId = 1, CallMeetingId = 1, Date = DateTime.Today, TimeHour = "09", TimeMinutes = "30", TimePeriod = "AM", RelatedTo = "Confirmation", Note = "Call" });
                _taskRepository.Post(new Task { CorpId = 1, ContactId = 1, CallMeetingId = 2, Date = DateTime.Today, TimeHour = "11", TimeMinutes = "20", TimePeriod = "AM", RelatedTo = "prueba", Note = "texto prueba1" });
                _taskRepository.Post(new Task { CorpId = 1, ContactId = 1, CallMeetingId = 3, Date = DateTime.Today, TimeHour = "02", TimeMinutes = "10", TimePeriod = "PM", RelatedTo = "prueba2", Note = "Call" });
            }
        }

        // GET api/Task
        public IEnumerable<Task> GetAllTasks()
        {
            //return Tasks;
            return _taskRepository.Get();
            throw new NotImplementedException();
        }

        // GET api/Default1/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult GetTask(DateTime Date)
        {
            var tasks = _taskRepository.Get(1, 1, Date);

            if (tasks == null)
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Task not found")
                });
            }
            return Ok(tasks);
        }

        // PUT api/Default1/5
        public IHttpActionResult PutTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _taskRepository.Post(task);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Default1
        [ResponseType(typeof(Task))]
        public IHttpActionResult PostTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _taskRepository.Post(task);

            //db.Tasks.Add(task);
            //db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { CallMeetingId = task.CallMeetingId }, task);
        }

        // DELETE api/Default1/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(Task task)
        {
            var Task = _taskRepository.Delete(task);
            if (!Task)
            {
                return NotFound();
            }

            //db.Tasks.Remove(Task);
            //db.SaveChanges();

            return Ok(Task);
        }
    }
}
