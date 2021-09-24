using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    [Serializable()]
    public class User
    {
        public string Id { get; set; }
        public Employee EmployeementInformation { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLogin { get; set; }
        public UserRole Role { get; set; }
        public Customer CustomerInformation { get; set; }
        public bool IsValidUser { get; set; }
        public bool? IsEmployee { get; set; }
    }
}
