using System;
using System.Collections.Generic;

namespace ContactBookApi.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int ContactId { get; set; }
        public int? AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public AddressType AddressType { get; set; }
        public Contact Contact { get; set; }
    }
}
