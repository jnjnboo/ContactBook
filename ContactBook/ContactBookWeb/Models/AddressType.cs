using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class AddressType
    {
        public AddressType()
        {
            Address = new HashSet<Address>();
        }

        public int AddressTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
