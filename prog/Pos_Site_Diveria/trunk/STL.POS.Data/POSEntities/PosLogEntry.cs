using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{
    public enum Categories
    {
        General,
        Error
    }

    [Table("POS_LOG_ENTRY")]
    public class PosLogEntry : LogEntry
    {

        public int Id { get; set; }

        private Categories category;

        public Categories Category
        {
            get { return category; }
            set
            {
                this.Categories.Add(value.ToString());
                category = value;
            }
        }

        public int QuotationId { get; set; }

        public string CurrentUser { get; set; }

    }
}
