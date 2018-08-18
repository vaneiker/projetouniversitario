using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacion
{
   public class ApplicationUser
   {
	   public string UserLoggedIn { get; set; }
	   public int RolId { get; set; }
	   private static ApplicationUser _user = null;
	   
	   private ApplicationUser(){}
	   
	   public static ApplicationUser Instance
      {
        get
        {
        if (_user == null)
            _user = new ApplicationUser();
 
        return _user;
        }
      }
   }	   
}