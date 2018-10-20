using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.Data
{

    public enum MappingElementType
    {
        Storage = 1,
        Usage = 2,
        Color = 3,
        MaritalStatus = 4,
        VehicleType = 5
    }


    [Table("VIRTUAL_OFFICE_INTEGRATION", Schema = "Integration")]
    public class VirtualOfficeIntegration
    {

        public static int GetVirtualOfficeIdentificationType(string posType)
        {
            if (posType == "Cédula")
                return 1;
            else if (posType == "Licencia")
                return 3;
            else if (posType == "RNC")
                return 5;
            else if (posType == "Pasaporte")
                return 2;
            else return 0;
        }


        public int Id { get; set; }

        public MappingElementType ElementType { get; set; }

        public string ElementTypeName { get; set; }

        public string ElementName { get; set; }

        public string PosId { get; set; }

        public int VirtualOfficeId { get; set; }

    }
}
