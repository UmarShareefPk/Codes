using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusTicketingSystem.CL
{
   public class Hotel
    {
       public string Id { get; set; }
       public string Name { get; set; }
       public float RoomRent { get; set; }
       public int TotalRooms { get; set; }
       public int AvailableRooms { get; set; }
    }
}
