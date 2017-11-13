using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBookApi.Models.ViewModels
{
    public class LookupModels
    {
        public class AddressTypes
        {
            public int AddressTypeId { get; set; }
            public string Name { get; set; }
        }
        
        public class EmailTypes
        {
            public int EmailTypeId { get; set; }
            public string Name { get; set; }
        }

        public class EventTypes
        {
            public int EventTypeId { get; set; }
            public string Name { get; set; }
        }

        public class PhoneTypes
        {
            public int PhoneTypeId { get; set; }
            public string Name { get; set; }
        }

        public class WebsiteTypes
        {
            public int WebsiteTypeId { get; set; }
            public string Name { get; set; }
        }
    }
}
