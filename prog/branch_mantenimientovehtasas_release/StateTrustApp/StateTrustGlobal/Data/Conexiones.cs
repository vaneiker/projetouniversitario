using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTrustGlobal.Data
{
    
        public class GlobalDbContext : DbContext
        {
            public GlobalDbContext()
                : base("MantVehiculo.Properties.Settings.Global")
            {
            }

            
        }
        public class SysFlexDbContext : DbContext
        {
            public SysFlexDbContext()
                : base("MantVehiculo.Properties.Settings.Sysflex")
            {
            }


        }
        public class SysFlexDbContext_NC : DbContext
        {
            public SysFlexDbContext_NC()
                : base("MantVehiculo.Properties.Settings.Sysflex_NC")
            {
            }


        }
        public class Pos_SiteDbContext : DbContext
        {
            public Pos_SiteDbContext()
                : base("MantVehiculo.Properties.Settings.Pos_site")
            {
            }

        

          
        }


    
}
