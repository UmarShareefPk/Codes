using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class CustomerAccountInformation
    {
        public string Id { get; set; }
        public Customer CustomerInformation { get; set; }
        public string CreditCardNumber { get; set; }
        public float Amount { get; set; }
    }
}
