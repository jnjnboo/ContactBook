using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class PhoneType
    {
        public PhoneType()
        {
            Phone = new HashSet<Phone>();
        }

        public int PhoneTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Phone> Phone { get; set; }
    }
}
