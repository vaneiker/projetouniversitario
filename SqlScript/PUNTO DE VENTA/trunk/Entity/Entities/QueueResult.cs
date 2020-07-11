﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class QueueResult
    {
        public int? Queue_Id { get; set; }
        public string Case_Number { get; set; }
        public int? Call_Meeting_Id { get; set; }
        public int? Contact_Id { get; set; }
        public string Driver_GPS_Location { get; set; }
        public string Result { get; set; }
        public string IncidenceId { get; set; }
    }
}