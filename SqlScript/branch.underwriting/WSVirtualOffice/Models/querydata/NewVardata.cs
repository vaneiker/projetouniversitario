using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSVirtualOffice.Models.querydata
{
    class NewVardata
    {
        public static int FROMYEAR = 0;
        public static int TOYEAR = 1;
        public static int AMOUNT = 2;
        public static int EDIT = 3;
        public static int DELETE = 4;

        
        private String fromyear;
        private String toyear;
        private decimal amount;
        private long num;
        private int sno;
        private String edit;
        private String delete;


        public NewVardata(String fromyear, String toyear, decimal amount, long num,int sno)
        {
            this.fromyear = fromyear;
            this.toyear = toyear;
            this.amount = amount;
            this.num = num;
            this.sno = sno;
            this.edit = "edit";
            this.delete = "delete";
        }


        public String Fromyear
        {
            get { return this.fromyear; }
            set { this.fromyear = value; }
        }

        public String Toyear
        {
            get { return this.toyear; }
            set { this.toyear = value; }
        }

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        public String Edit
        {
            get { return this.edit; }
            set { this.edit = value; }
        }

        public String Delete
        {
            get { return this.delete; }
            set { this.delete = value; }
        }

        public int Sno
        {
            get { return this.sno; }
            set { this.sno = value; }
        }
        
        public long Num
        {
            get { return this.num; }
            set { this.num = value; }
        }

        



    }
}
