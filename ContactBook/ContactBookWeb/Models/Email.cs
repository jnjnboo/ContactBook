using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class Email
    {
        public int EmailId { get; set; }
        public string EmailAddress { get; set; }
        public int? EmailTypeId { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
        public EmailType EmailType { get; set; }
    }
}
