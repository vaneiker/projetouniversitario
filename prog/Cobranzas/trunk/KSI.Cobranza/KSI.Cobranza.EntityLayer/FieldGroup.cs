using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSI.Cobranza.EntityLayer
{
    public class DataFieldGroup
    {
        public int IdFieldGroup { get; set; }
        public string FieldGroupName { get; set; }
        public string FieldGroupDescripcion { get; set; }
        public string cssClassContent { get; set; }
        public string cssClassPanel { get; set; }
        public string HtmlTitle { get; set; }
        public string cssClassIcon { get; set; }
        public string HtmlValidationQuestion { get; set; }
        public int Ordinal { get; set; }
        public List<DataField> DataFields { get; set; }
    }
}
