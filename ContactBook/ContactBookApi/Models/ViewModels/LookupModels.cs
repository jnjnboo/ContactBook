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
            public int Id { get; set; }
            public string Name { get; set; }
        }
        
        public class EmailTypes
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class EventTypes
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class PhoneTypes
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class WebsiteTypes
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
