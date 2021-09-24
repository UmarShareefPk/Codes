using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CustomerSince { get; set; }
        public bool Active { get; set; }
    }
}
