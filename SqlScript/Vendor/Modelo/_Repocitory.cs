using Modelo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
   public  class _Repocitory
    {
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
                var ver = new Modelo.EN_AGENT_GP_COMMISSION_entity();

            if (id == 0)
            {
                return ver;
            }
                try
                {
                    using (var context = new GlobaContext())
                    {
                    ver = context.EN_AGENT_GP_COMMISSION
                                    .Where(x => x.Agent_Id == id && x.Agent_Status == true)
                                    .Select(x => new Modelo.EN_AGENT_GP_COMMISSION_entity
                                    {
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


        public IEnumerable<EN_AGENT_GP_COMMISSION_entity> Listado()
        {
            using (GlobaContext context = new GlobaContext())
            {
                //CREAR METODO EN POS_SITE DE PRODUCCION
                IEnumerable<EN_AGENT_GP_COMMISSION_entity> RetornarValue = context.Database.SqlQuery<EN_AGENT_GP_COMMISSION_entity>("EXEC SP_GET_LIST_VENDOR_ACTIVE").ToList();

                return RetornarValue.ToList();
            }
        }


        public IEnumerable<EN_AGENT_GP_COMMISSION_entity>SearchVendor(string a , string b)
        {
            using (GlobaContext context = new GlobaContext())
            {
                //CREAR METODO EN POS_SITE DE PRODUCCION
                IEnumerable<EN_AGENT_GP_COMMISSION_entity> RetornarValue = context.Database.SqlQuery<EN_AGENT_GP_COMMISSION_entity>("EXEC SP_GET_LIST_VENDOR_SEARCH @Agent_Id,@Vendor_Id ",
                      new SqlParameter("@Agent_Id", a),
                    new SqlParameter("@Vendor_Id", int.Parse(b))).ToList();
                return RetornarValue.ToList();
            }
        }





        //SP_GET_LIST_VENDOR_ACTIVE





        public bool AddVendor(EN_AGENT_GP_COMMISSION_entity ent)
        {
            try
            {
                using (GlobaContext context = new GlobaContext())
                {

                    var connection = context.Database.Connection as SqlConnection;

                    using (connection)
                    {
                        connection.Open();
                        string Qry = "SP_SET_CREATE_VENDOR_GP";
                        SqlCommand cmd = new SqlCommand(Qry, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Agent_Id", ent.Agent_Id));
                        cmd.Parameters.Add(new SqlParameter("@Vendor_Id", ent.Vendor_Id));
                        cmd.Parameters.Add(new SqlParameter("@Create_UserId", ent.Create_UsrId));
                        cmd.ExecuteNonQuery();
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

    }
}
