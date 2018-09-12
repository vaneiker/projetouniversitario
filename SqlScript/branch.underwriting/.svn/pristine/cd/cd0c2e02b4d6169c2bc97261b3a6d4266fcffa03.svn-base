using System;
using System.Collections.Generic;
using System.Web;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.CallAndVisits
{
    public class CustomEventDataSource
    {
        CustomEventList events;
        public CustomEventDataSource(CustomEventList events)
        {
            if (events == null)
                DevExpress.XtraScheduler.Native.Exceptions.ThrowArgumentNullException("events");
            this.events = events;
        }
        public CustomEventDataSource()
            : this(new CustomEventList())
        {
        }
        public CustomEventList Events { get { return events; } set { events = value; } }
        public int Count { get { return Events.Count; } }

        #region ObjectDataSource methods
        public object InsertMethodHandler(CustomEvent customEvent)
        {
            Object id = customEvent.GetHashCode();
            customEvent.Id = id;
            Events.Add(customEvent);
            Events.Add(new CustomEvent { Description = "Prueba", Subject = "Prueba", Label = 0, Status = 4, Id = this.GetHashCode(), StartTime = DateTime.Now.AddHours(-1), EndTime = DateTime.Now.AddHours(-1), Location = "", ReminderInfo = "" });
            return id;
        }
        public void DeleteMethodHandler(CustomEvent customEvent)
        {
            int eventIndex = Events.GetEventIndex(customEvent.Id);
            if (eventIndex >= 0)
                Events.RemoveAt(eventIndex);
        }
        public void UpdateMethodHandler(CustomEvent customEvent)
        {
            int eventIndex = Events.GetEventIndex(customEvent.Id);
            if (eventIndex >= 0)
            {
                Events.RemoveAt(eventIndex);
                Events.Insert(eventIndex, customEvent);
            }
        }
        public CustomEventList SelectMethodHandler()
        {
            CustomEventList result = new CustomEventList();
            result.AddRange(Events);
            return result;
        }
        #endregion

        public object ObtainLastInsertedId()
        {
            if (Count < 1)
                return null;
            return Events[Count - 1].Id;
        }
    }
}