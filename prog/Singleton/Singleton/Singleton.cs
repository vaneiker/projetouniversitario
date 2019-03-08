using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Singleton
    {
        private static Singleton instance = null;

        #region Managers
        public ContactManager oContactManger { get; set; }
        public GlobalEntities oContext { get; set; }
        #endregion

        private Singleton()
        {
            oContactManger = new ContactManager();
            oContext = new GlobalEntities();
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
