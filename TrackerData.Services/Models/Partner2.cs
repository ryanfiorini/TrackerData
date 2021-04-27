using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerData.Services.Models
{
    public class Partner2
    {
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public List<Device> Devices { get; set; }
    }
}
