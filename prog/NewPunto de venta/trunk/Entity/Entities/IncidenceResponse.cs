﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class IncidenceResponse
    {
        public int pkStChat { get; set; }
        public long chatDate { get; set; }
        public string chatStatus { get; set; }
        public int StClient { get; set; }
        public string strChatDate { get; set; }
    }
}