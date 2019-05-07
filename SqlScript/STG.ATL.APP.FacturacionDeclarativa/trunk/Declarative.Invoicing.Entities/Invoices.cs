using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Declarative.Invoicing.Entities
{
    public class Invoices
    {
        public string FacturaNumero { get; set; }
        public string Poliza { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Ncf { get; set; }
        public Nullable<int> CantidadFacturados { get; set; }
        public Nullable<decimal> PrimaNeta { get; set; }
        public Nullable<decimal> ISC { get; set; }
        public Nullable<decimal> TotalAPagar { get; set; }
        public Nullable<int> CodigoConcepto { get; set; }
        public string Concepto { get; set; }
        public Nullable<decimal> ValorFactura { get; set; }
        public Nullable<decimal> ValorItbis { get; set; }
        public Nullable<int> SecuenciaMov { get; set; }
        public string TipoComprobante { get; set; }
        public string cedulaCliente { get; set; }
        public string NombreCliente { get; set; }
        public Nullable<int> CodigoVendedor { get; set; }
        public string Direccion { get; set; }
        public Nullable<decimal> CodigoCliente { get; set; }
        public string TelRes { get; set; }
        public string TelOfic { get; set; }
        public string TelCel { get; set; }
        public string CodigoSupervisor { get; set; }
        public string NombreSupervisor { get; set; }
        public string NombreVendedor { get; set; }
        public string CodigoAgente { get; set; }
        public string DireccionAgente { get; set; }
        public string VigenciaDesde { get; set; }
        public string VigenciaHasta { get; set; }
        public string Oficina { get; set; }
        public string Ramo { get; set; }
        public Nullable<decimal> SumaAsegurada { get; set; }
        public string UserName { get; set; }
        public string Producto { get; set; }

        public string ValorFacturaString { get; set; }
        public string FechaString { get; set; }


        public class InvoiceHeaderParams
        {
            public int? Id { get; set; }
            public long CoreQuotNumber { get; set; }
            public int SecuenciaMov { get; set; }
            public string InvoiceNumber { get; set; }
            public decimal InvoiceAmount { get; set; }
            public DateTime InvoicingPeriod { get; set; }
            public DateTime? LastExclusion { get; set; }
            public DateTime? LastInclusion { get; set; }
            public int UserId { get; set; }
            public DateTime? initialDate { get; set; }
            public DateTime? EndDate { get; set; }
            public int PolicyInfoId { get; set; }
            public int PeriodPolicyId { get; set; }            
        }

        public class InvoiceDetailParams
        {
            public int? Id { get; set; }
            public int InvoiceHeaderId { get; set; }
            public int Item { get; set; }
            public string ClientName { get; set; }
            public int MakeId { get; set; }
            public string MakeName { get; set; }
            public int ModelId { get; set; }
            public string ModelName { get; set; }
            public int Year { get; set; }
            public string Chassis { get; set; }
            public string Plate { get; set; }
            public DateTime DateProcess { get; set; }
            public decimal Amount { get; set; }
            public string Status { get; set; }
        }

    }



}
