using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFacturacion.AppTools
    {
   public class LogicRoll
        {
      public  enum LevelRol
            { 
	        Administrador=1,
	        Almacenista=2,
	        Vendedor=3,
	        AlmacenistaSup=4,
	        VendedorSup=5,
	        Gerente=6,
	        HHRR=7
           }


        public static string Cargos(LevelRol cargo)
            {
            string _cargo = "";
               switch(cargo)
                {
                case LevelRol.Administrador:
                    _cargo =  "Administrador";
                    break;
                case LevelRol.Almacenista:
                    _cargo = "Almacenista";
                    break;
                case LevelRol.AlmacenistaSup:
                    _cargo = "Supervisor de Almacen";
                    break;
                case LevelRol.Gerente:
                    _cargo = "Gerente de Produccion";
                    break;
                case LevelRol.HHRR:
                    _cargo = "Especialista de Recursos Humanos";
                    break;
                case LevelRol.Vendedor:
                    _cargo = "Cajero";
                    break;
                case LevelRol.VendedorSup:
                    _cargo = "Supervisor de Caja";
                    break;

                }

              return _cargo;
            }

        }
    }
