using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.ViewModels
{
    public class VersionViewModel
    {
        public List<SPCBuscaTipoCapacidadModelo> version { get; set; }
        public VersionViewModel()
        {
            this.version = new List<SPCBuscaTipoCapacidadModelo>();
        }

        public IEnumerable<int> getSelectedIds()
        {
            return (from p in this.version where p.IsChecked select p.IdListaHeader).ToList();
        }
    }
}
