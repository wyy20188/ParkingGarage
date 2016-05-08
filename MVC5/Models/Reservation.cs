using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string SpotID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReserveTime { get; set; }
        public DateTime LastEdit { get; set; }
        public string Status { get; set; }
    }
}