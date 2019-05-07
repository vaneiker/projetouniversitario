using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Entities
{
    public class Queue
    {
        public string poliza { get; set; }
        public Nullable<long> cotizacion { get; set; }
        public string asegurado { get; set; }
        public string periodoFacturacion { get; set; }
        public int itemsActivos { get; set; }
        public Nullable<System.DateTime> fechaFacturacion { get; set; }
        public Nullable<decimal> montoUltFactura { get; set; }
        public Nullable<System.DateTime> fechaUltFactura { get; set; }
        public Nullable<System.DateTime> ultExclusion { get; set; }
        public Nullable<System.DateTime> ultInclusion { get; set; }

        public int id { get; set; }
        public System.DateTime periodoInicio { get; set; }
        public System.DateTime periodoFin { get; set; }
        public string estatusPeriodo { get; set; }
        public int periodId { get; set; }
        public int periodPolicyId { get; set; }
        public string intermediario { get; set; }

        public class Periods
        {
            public int Id { get; set; }
            public string Period_Name { get; set; }
            public System.DateTime StartDate { get; set; }
            public System.DateTime EndDate { get; set; }
            public System.DateTime Billing_Date { get; set; }
        }

        public class Historic
        {
            public int id { get; set; }
            public string poliza { get; set; }
            public string asegurado { get; set; }
            public string periodoFacturacion { get; set; }
            public System.DateTime periodoFechaFin { get; set; }
            public System.DateTime fechaFacturacion { get; set; }
            public int itemsFacturados { get; set; }
            public decimal montoUltFactura { get; set; }
            public Nullable<System.DateTime> fechaUltFactura { get; set; }
            public Nullable<System.DateTime> ultExclusion { get; set; }
            public Nullable<System.DateTime> ultInclusion { get; set; }
            public long cotizacion { get; set; }
            public System.DateTime periodoInicio { get; set; }
            public System.DateTime periodoFin { get; set; }
            public string estatusPeriodo { get; set; }
            public int periodId { get; set; }
            public string invoiceNumber { get; set; }
        }
    }


}
