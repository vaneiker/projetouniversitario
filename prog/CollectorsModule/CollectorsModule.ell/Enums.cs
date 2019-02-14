using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsModule.ell
{
    public class Enums
    {
        public enum ReportTypes
        {
            [Description("Reporte Diario")]
            IndividualToday =1,
            [Description("Reporte Por Rango de Fecha")]
            IndividualRange = 2,
            [Description("Reporte Diario")]
            BatchToday = 3,
            [Description("Reporte Por Rango de Fecha")]
            BatchRange = 4
        }
    }
}
