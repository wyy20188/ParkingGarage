using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Park
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ReservationID { get; set; }
        public DateTime ArriveTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public int ParkMinute { get; set; }
        public double Fee { get; set; }
        public string LicensePlate { get; set; }
        public string SpotID { get; set; }
    }
}