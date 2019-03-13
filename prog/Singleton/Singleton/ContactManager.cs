using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ContactManager
    {
        public IEnumerable<string> Getcontact()
        {

            return new List<string> { "Carlos" };
        }

        public IEnumerable<string> Getcontact2()
        {

            return new List<string> { "Carlos" };
        }

        public IEnumerable<string> Getcontact3()
        {

            return new List<string> { "Carlos" };
        }
    }
}
