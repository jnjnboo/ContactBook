using System;
using System.Collections.Generic;

namespace ContactBookWeb.Models
{
    public partial class User
    {
        public User()
        {
            Contact = new HashSet<Contact>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string LogonName { get; set; }
        public byte[] Photo { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Contact> Contact { get; set; }
    }
}
