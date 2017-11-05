using System;
using System.Collections.Generic;

namespace ContactBookApi.Models
{
    public partial class Website
    {
        public int WebsiteId { get; set; }
        public int ContactId { get; set; }
        public string Url { get; set; }
        public int? WebsiteTypeId { get; set; }

        public Contact Contact { get; set; }
        public WebsiteType WebsiteType { get; set; }
    }
}
