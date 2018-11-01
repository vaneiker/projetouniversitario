using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ReAssignNCF
{
    public class Buscar
    {
        private SysFlexSegurosEntities db = new SysFlexSegurosEntities();

        //int[] TipoDoc = { 8, 10 }; // Credito y Facturas
        //ListTipoDoc.ListaTipoDocABuscar();

        TipoDoc tipoDoc = new TipoDoc();

        public IEnumerable<InfoNCFPolizas> ObtenerPolizasConNCF()
        {

            TipoDoc tipoDoc = new TipoDoc();
            
            var ListaPolizas = from rg in db.IN_DocumentoCobrar
                               where tipoDoc.ListaTipoMovimientoABuscar.Contains(rg.Tipo) &&  rg.Ncf.Length > 10
                                && (db.ReassignNCF_log.Any(log => rg.Poliza != log.Poliza && rg.Ncf != log.Ncf_new))
                               select new InfoNCFPolizas
                               {
                                   Poliza = rg.Poliza.Trim(),
                                   TipoDocumento = rg.Tipo,
                                   FacturaAnterior = rg.FacturaAnterior,
                                   Valor = rg.Valor,
                                   ValorItbis = rg.ValorItbis,
                                   NCF = rg.Ncf.Trim()
                                   
                               };

            return ListaPolizas.OrderBy(o => o.Poliza).ThenBy(t => t.NCF).Take(50);
                        
        }

        public IEnumerable<InfoNCFPolizas> ObtenerPolizasConNCF(InfoNCFPolizas polizas)
        {

           
            var ListaPolizas = from rg in db.IN_DocumentoCobrar
                               where tipoDoc.ListaTipoMovimientoABuscar.Contains(rg.Tipo) && rg.Poliza == polizas.Poliza && rg.Ncf == polizas.NCF
                               && (db.ReassignNCF_log.Any(log => rg.Poliza != log.Poliza && rg.Ncf != log.Ncf_new))
                               select new InfoNCFPolizas
                               {
                                   Poliza = rg.Poliza.Trim(),
                                   TipoDocumento = rg.Tipo,
                                   FacturaAnterior = rg.FacturaAnterior,
                                   Valor = rg.Valor,
                                   ValorItbis = rg.ValorItbis,
                                   NCF = rg.Ncf.Trim()
                               };

            return ListaPolizas.OrderBy(o => o.Poliza).ThenBy(t => t.NCF).Take(50);

        }
                
    }
    
}
