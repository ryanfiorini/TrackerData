using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerData.Services.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string ShipmentStartDtm { get; set; }
        public List<Sensor> Sensors { get; set; }
    }
}
