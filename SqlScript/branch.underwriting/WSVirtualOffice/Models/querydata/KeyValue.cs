using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSVirtualOffice.Models.querydata
{
    public class KeyValue
    {
        private String key;

        private String valuest;



        public KeyValue(String key, String valuest)
        {
            this.key = key;
            this.valuest = valuest;
        }


        public String Key
        {
            get { return key; }
            set { key = value; }
        }

        public String Valuest
        {
            get { return valuest; }
            set { valuest = value; }
        }
    }
}