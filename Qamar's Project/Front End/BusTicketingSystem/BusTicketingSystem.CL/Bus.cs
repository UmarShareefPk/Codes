using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class Bus
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public BusType Type { get; set; }
        public Terminal TerminalInformation { get; set; }
        public int? NumberOfSeats { get; set; }
        public int? AvailableSeats { get; set; }
        public int? TotalWeight { get; set; }
        public int? AvailableWait { get; set; }
        public Employee Driver { get; set; }
        public Employee Doctor { get; set; }
        public Employee BusHostess { get; set; }
        public Employee SecurityGuard { get; set; }
    }
}
