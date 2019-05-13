using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipLogs.Entity.Entity
{
    public partial class AddressBookEntity
    {
        public int UniqueAddressID { get; set; }
        public string Name { get; set; }
        public string ATTN { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public int? MaxWeeklyShipments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedAtWorkstation { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedAtWorkstation { get; set; }
        public string ModifiedByUser { get; set; }
    }
}
