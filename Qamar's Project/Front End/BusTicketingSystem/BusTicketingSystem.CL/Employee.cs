using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public Terminal TerminalInformation { get; set; }
        public string Phone { get; set; }
        public float Salary { get; set; }
        public DateTime HireDate { get; set; }
        
    }
}
