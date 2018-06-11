using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.AppTools;

namespace SistemaFacturacion
    {

    public class Seccion
        {
        public string Usuario { get; set; }
        public  LogicRoll.LevelRol Rolid { get; set; }

        private static Seccion _user = null;

        private Seccion() { }

        public static Seccion Instance
            {
            get
                {
                if (_user == null)
                    _user = new Seccion();

                return _user;
                }

            }
        }
    }