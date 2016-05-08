using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Car
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string LicensePlate { get; set; } 
        public string Status { get; set; }
        public string AddTime { get; set; }
        public User User { get; set; }
    }
}