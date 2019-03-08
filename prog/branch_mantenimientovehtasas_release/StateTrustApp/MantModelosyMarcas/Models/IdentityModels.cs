using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MantModelosyMarcas.Models
{
 

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("MantVehiculo.Properties.Settings.Global")
        {
        }
        
    }
}