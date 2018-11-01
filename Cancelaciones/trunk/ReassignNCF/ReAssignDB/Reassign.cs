using ReAssignNCF.ncf.svc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReAssignNCF
{
    public class Reassign
    {
        SysFlexSegurosEntities db = new SysFlexSegurosEntities();

        public bool Actualiza(string poliza, string ncf)
        {

            var _facturaOld = "";
            var _ncfOld = "";
            var _facturaNew = "";
            var _ncfNew = "";

            IncfClient client = new IncfClient();

            var resultado = db.IN_DocumentoCobrar.FirstOrDefault(p => p.Poliza == poliza && p.Ncf == ncf);

            if (resultado == null) return false;

            _facturaOld = resultado.FacturaAnterior;
            _ncfOld = resultado.Ncf;

            if (resultado.Tipo == 10)
            {
                
                var SvcResult = client.GetNCFandInvoiceNumber(poliza, DateTime.Now, (decimal)resultado.Valor, (decimal)resultado.ValorItbis);
                
                _facturaNew = SvcResult.InvoiceNumber;
                _ncfNew = SvcResult.NCFNumber;

            } else if(resultado.Tipo == 8) {

                var SvcResult = client.GetNCFandCreditNumber(poliza, DateTime.Now, (decimal)resultado.Valor, (decimal)resultado.ValorItbis);
                
                _facturaNew = SvcResult.CreditNumber;
                _ncfNew = SvcResult.NCFNumber;

            }
            
            ReassignNCF_log _log = new ReassignNCF_log
            {
                 Poliza = resultado.Poliza,
                 Valor_old = (decimal)resultado.Valor,
                 ValorItbis_old = (decimal)resultado.ValorItbis,
                 Valor_new = (decimal)resultado.Valor,
                 ValorItbis_new = (decimal)resultado.ValorItbis,
                 Ncf_old = _ncfOld,
                 Factura_old = _facturaOld,
                 Ncf_new = _ncfNew,
                 Factura_new = _facturaNew,
                 fecha_actualizacion = DateTime.Now
            };

            resultado.FacturaAnterior = _facturaNew;
            resultado.Ncf = _ncfNew;

            client.Close();

            try
            {

                db.Entry(resultado).State = System.Data.Entity.EntityState.Modified;
                db.Entry(_log).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
                throw;

            }   
        }

    }
}
