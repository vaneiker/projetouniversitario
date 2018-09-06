using Modelo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public  class EN_AGENT_GP_COMMISSION_entity  
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Corp_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Agent_Id { get; set; }
        public bool No_Commission { get; set; }
        public bool Take_Vendor_Id { get; set; }
        [StringLength(50)]
        public string Vendor_Id { get; set; }
        public bool Agent_Status { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Modi_Date { get; set; }
        public int Create_UsrId { get; set; }
        public int? Modi_UsrId { get; set; }
        [Required]
        [StringLength(100)]
        public string Hostname { get; set; }



        public List<EN_AGENT_GP_COMMISSION_entity> ListadoGpAgent()
            {
                var l = new List<EN_AGENT_GP_COMMISSION_entity>();
                using (var cxt = new GlobaContext())
                {
                    var p = from a in cxt.EN_AGENT_GP_COMMISSION
                            where (a.Agent_Status == true)
                            orderby a.Vendor_Id ascending
                            select new EN_AGENT_GP_COMMISSION_entity {
                               Agent_Id=a.Agent_Id
                               ,No_Commission=a.No_Commission
                               ,Take_Vendor_Id=a.Take_Vendor_Id
                               ,Vendor_Id=a.Vendor_Id
                               ,Create_Date=a.Create_Date
                            };
                    l = p.ToList();
                    return l;
                }
            }


            public EN_AGENT_GP_COMMISSION_entity Obtener(int id)
            {
                var ver = new EN_AGENT_GP_COMMISSION_entity();
                try
                {
                    using (var context = new GlobaContext())
                    {
                    ver = context.EN_AGENT_GP_COMMISSION
                                    .Where(x => x.Agent_Id == id && x.Agent_Status == true)
                                    .Select(x => new EN_AGENT_GP_COMMISSION_entity {
                                        Agent_Id = x.Agent_Id                               
                                        ,No_Commission = x.No_Commission
                                        ,Take_Vendor_Id = x.Take_Vendor_Id
                                        ,Vendor_Id = x.Vendor_Id
                                        ,Create_Date = x.Create_Date
                                    }).Single();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

                return ver;
            }
      
    }
}
