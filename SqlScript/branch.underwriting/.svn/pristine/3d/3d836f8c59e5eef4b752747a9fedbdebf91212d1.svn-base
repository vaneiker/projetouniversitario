using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WEB.NewBusiness.NewBusiness.UserControls.Contact.CallAndVisits
{
    [Serializable]
    public class CustomEventList : BindingList<CustomEvent>
    {
        public void AddRange(CustomEventList events)
        {
            foreach (CustomEvent customEvent in events)
                this.Add(customEvent);
        }
        public int GetEventIndex(object eventId)
        {
            for (int i = 0; i < Count; i++)
                if (this[i].Id == eventId)
                    return i;
            return -1;
        }
    }
}