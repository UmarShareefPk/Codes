using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class BusSeat
    {
        public string Id { get; set; }
        public Route route { get; set; }
        public int SeatNumber { get; set; }
        public bool IsBooked { get; set; }
        public string Type { get; set; }
    }
}
