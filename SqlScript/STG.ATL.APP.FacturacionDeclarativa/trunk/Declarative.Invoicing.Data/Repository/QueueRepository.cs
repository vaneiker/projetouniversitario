using Declarative.Invoicing.Data.EdmxModel;
using Declarative.Invoicing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Declarative.Invoicing.Data.Repository
{
    public class QueueRepository : BaseRepository
    {
        public QueueRepository() { }

        public virtual IEnumerable<Queue> GetQueue(string policy, DateTime? DateBilling)
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
                ultInclusion = q.UltInclusion,
                estatusPeriodo = q.EstatusPeriodo,
                id = q.Id,
                periodoFin = q.PeriodoFin,
                periodoInicio = q.PeriodoInicio,
                periodId = q.PeriodId,
                periodPolicyId = q.PeriodPolicyId,
                intermediario = q.Intermediario
            })
            .ToArray();

            return result;
        }

        public virtual IEnumerable<Queue.Periods> GetPeriods(DateTime? Date)
        {
            IEnumerable<Queue.Periods> result;
            IEnumerable<SP_GET_PERIODS_Result> temp;
            temp = DeInContex.SP_GET_PERIODS(Date);

            result = temp.Select(q => new Queue.Periods()
            {
                Billing_Date = q.Billing_Date,
                EndDate = q.EndDate,
                Id = q.Id,
                Period_Name = q.Period_Name,
                StartDate = q.StartDate
            })
            .ToArray();

            return result;
        }

        public virtual IEnumerable<Queue.Historic> GetHistoric(string policy)
        {
            IEnumerable<Queue.Historic> result;
            IEnumerable<SP_GET_HISTORIC_Result> temp;
            temp = DeInContex.SP_GET_HISTORIC((policy == "" ? null : policy));

            result = temp.Select(q => new Queue.Historic()
            {
                poliza = q.Poliza,
                cotizacion = q.Cotizacion,
                asegurado = q.Asegurado,
                itemsFacturados = q.ItemsFacturados,
                periodoFacturacion = q.PeriodoFacturacion,
                fechaFacturacion = q.FechaFacturacion,
                fechaUltFactura = q.FechaUltFactura,
                montoUltFactura = q.MontoUltFactura,
                ultExclusion = q.UltExclusion,
                ultInclusion = q.UltInclusion,
                estatusPeriodo = q.EstatusPeriodo,
                id = q.Id,
                periodoFin = q.PeriodoFin,
                periodoInicio = q.PeriodoInicio,
                periodId = q.PeriodId,
                periodoFechaFin = q.PeriodoFechaFin,
                invoiceNumber = q.Invoice_Number
            })
            .ToArray();

            return result;
        }


    }
}
