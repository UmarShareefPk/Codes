using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class Reservation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
        public string Phone { get; set; }
        public BusSeat BusSeatInformation { get; set; }
        public Route RouteInformation { get; set; }
        public string Email { get; set; }
        public Customer CustomerInformation { get; set; }
        public bool ConfirmReservation { get; set; }

    }
}
