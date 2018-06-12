using static SistemaFacturacion.AppTools.LogicRoll;

namespace SistemaFacturacion
{
    public class Seccion
    {
        private static Seccion _user = null;

        public string Usuario { get; set; }
        public  LevelRol Rolid { get; set; }

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