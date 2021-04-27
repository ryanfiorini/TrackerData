using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerData.Services.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Crumb> Crumbs { get; set; }
    }
}
