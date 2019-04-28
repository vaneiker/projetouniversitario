using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APP_Concurso.Models
{
    public class ConcursoEntity
    {
        public string Poliza { get; set; }
        public string NombreCliente { get; set; }

        public string ExceptionMessenger { get; set; }
    }
    public class Repocitory
    {
        public IEnumerable<ConcursoEntity> GetConcursoList()
        {
            var result = new List<ConcursoEntity>();
            using (SystemDBventasNewEntities context = new SystemDBventasNewEntities())
            {
                result = context.Concunsars.Select(x => new ConcursoEntity
                {
                    NombreCliente = x.NombreCliente,
                    Poliza = x.Poliza
                }).ToList();

                return result;
            }
        }

        public ConcursoEntity GetConcurso()
        {
            var l = new ConcursoEntity();
            try
            {
                using (SystemDBventasNewEntities context = new SystemDBventasNewEntities())
                {
                    IEnumerable<ConcursoEntity> RetornarValue = context.Database.SqlQuery<ConcursoEntity>("exec sp_get_random").ToList();
                    return RetornarValue.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
               
                l.ExceptionMessenger = ex.Message.ToString();
                return l;
            }

        }
    }
}