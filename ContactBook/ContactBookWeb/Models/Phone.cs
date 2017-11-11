using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public int? PhoneTypeId { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}
