using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using System.Windows.Forms;

namespace ReAssignNCF
{
    public class TipoDoc
    {
        SysFlexSegurosEntities _db = new SysFlexSegurosEntities();

        string[] separators = { "," };

        public int[] ListaTipoMovimientoABuscar {get;set;}

        int CompanyId = 0;

        public TipoDoc()
        {
            try
            {

            string _lstTipoMov = ConfigurationManager.AppSettings["TipoDocABuscar"].ToString();

            GetCompanyId();

            string[] tipoMov = _lstTipoMov.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            ListaTipoMovimientoABuscar = Array.ConvertAll<string, int>(tipoMov, int.Parse);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void GetCompanyId()
        {
            try
            {
                CompanyId = int.Parse(ConfigurationManager.AppSettings["CompanyId"]);
            }
            catch (Exception)
            {
                
                throw new Exception("CompanyID debe ser númerico.");
            }
            
        }

        public List<TipoMovimiento> Obtener
        {
            get
            {
                var lstTipoDoc = from doc in _db.Tipo_Movimiento
                                 where ListaTipoMovimientoABuscar.Contains(doc.Codigo) && doc.Compania == CompanyId
                                 select new TipoMovimiento
                                 {
                                     Id = doc.Codigo,
                                     Nombre = doc.Descripcion
                                 };

                return lstTipoDoc.ToList();

            }

        }
        
    }

    public class TipoMovimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
