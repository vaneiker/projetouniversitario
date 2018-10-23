﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class CoverageDetailBrochure
    {
        public int Id { get; set; }
        public string CoverageName { get; set; }
        public string Value { get; set; }
        public Nullable<int> CoverageBrochureId { get; set; }
        public string CoverageType { get; set; }
        
    }
}