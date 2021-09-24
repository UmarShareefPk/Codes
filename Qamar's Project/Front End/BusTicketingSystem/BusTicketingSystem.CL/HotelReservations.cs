using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
    public class HotelReservations
    {
        public string Id { get; set; }
        public Customer CustomerInformation { get; set; }
        public int RoomNumber { get; set; }
        public Hotel HotelInformation { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime LeaveTime { get; set; }
    }
}
