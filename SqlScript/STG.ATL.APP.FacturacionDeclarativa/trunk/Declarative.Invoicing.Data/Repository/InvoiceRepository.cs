using Declarative.Invoicing.Data.EdmxModel;
using Declarative.Invoicing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Declarative.Invoicing.Data.Repository
{
    public class InvoiceRepository : BaseRepository
    {
        public InvoiceRepository() { }

        public virtual IEnumerable<Queue> InvoiceData(string policy, DateTime? DateBilling)
        {
            IEnumerable<Queue> result;
            IEnumerable<SP_GET_QUEUE_Result> temp;
            temp = DeInContex.SP_GET_QUEUE(policy, DateBilling);

            result = temp.Select(q => new Queue()
            {
                poliza = q.Poliza,
                cotizacion = q.Cotizacion,
                asegurado = q.Asegurado,
                itemsActivos = q.ItemsActivos,
                periodoFacturacion = q.PeriodoFacturacion,
                fechaFacturacion = q.FechaFacturacion,
                fechaUltFactura = q.FechaUltFactura,
                montoUltFactura = q.MontoUltFactura,
                ultExclusion = q.UltExclusion,
                ultInclusion = q.UltInclusion
            })
            .ToArray();

            return result;
        }

        public virtual BaseEntities SetInvoiceHeader(Invoices.InvoiceHeaderParams parameters)
        {
            IEnumerable<BaseEntities> result;
            IEnumerable<SP_SET_INVOICE_HEADER_DATA_Result> temp;
            temp = DeInContex.SP_SET_INVOICE_HEADER_DATA(
                parameters.Id,
                parameters.CoreQuotNumber,
                parameters.SecuenciaMov,
                parameters.InvoiceNumber,
                parameters.InvoiceAmount,
                parameters.InvoicingPeriod,
                parameters.LastExclusion,
                parameters.LastInclusion,
                parameters.UserId,
                parameters.initialDate,
                parameters.EndDate,
                parameters.PolicyInfoId,
                parameters.PeriodPolicyId);

            result = temp.Select(q => new BaseEntities()
            {
                Action = q.Action,
                Id = q.Id
            });

            return result.FirstOrDefault();
        }

        public virtual BaseEntities SetInvoiceDetail(Invoices.InvoiceDetailParams parameters)
        {
            IEnumerable<BaseEntities> result;
            IEnumerable<SP_SET_INVOICE_DETAIL_DATA_Result> temp;
            temp = DeInContex.SP_SET_INVOICE_DETAIL_DATA(
                parameters.Id,
                parameters.InvoiceHeaderId,
                parameters.Item,
                parameters.ClientName,
                parameters.MakeId,
                parameters.MakeName,
                parameters.ModelId,
                parameters.ModelName,
                parameters.Year,
                parameters.Chassis,
                parameters.Plate,
                parameters.DateProcess,
                parameters.Amount,
                parameters.Status
                );

            result = temp.Select(q => new BaseEntities()
            {
                Action = q.Action,
                Id = q.Id
            });

            return result.FirstOrDefault();
        }

        public virtual int SetPeriodInvoiced(Nullable<int> policyInfoId, Nullable<int> periodId, Nullable<System.DateTime> processDate)
        {
            return DeInContex.SP_SET_PERIOD_INVOICED(policyInfoId, periodId, processDate);
        }

    }
}
