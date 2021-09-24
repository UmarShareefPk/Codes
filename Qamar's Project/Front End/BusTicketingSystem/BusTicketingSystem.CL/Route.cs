using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class Route
    {
        public string Id { get; set; }
        public Bus bus { get; set; }
        public Terminal TerminalA { get; set; }
        public Terminal TerminalB { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public float Fare { get; set; }
        public RouteType Type { get; set; }
    }
}
