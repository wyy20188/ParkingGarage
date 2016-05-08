using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5.Models
{
    public class Spot
    {
        public int ID { get; set; }
        public int LevelID { get; set; }
        public int RowID { get; set; }
        public int ColumnID { get; set; }
        public string SpotID { get; set; }
        public string Status { get; set; }
    }
}