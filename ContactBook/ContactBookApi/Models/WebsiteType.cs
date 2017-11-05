using System;
using System.Collections.Generic;

namespace ContactBookApi.Models
{
    public partial class WebsiteType
    {
        public WebsiteType()
        {
            Website = new HashSet<Website>();
        }

        public int WebsiteTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Website> Website { get; set; }
    }
}
