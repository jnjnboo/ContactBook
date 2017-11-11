using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class EmailType
    {
        public EmailType()
        {
            Email = new HashSet<Email>();
        }

        public int EmailTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Email> Email { get; set; }
    }
}
