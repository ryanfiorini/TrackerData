using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerData.Services.Models
{
    public class Partner1
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public List<Tracker> Trackers { get; set; }
    }
}
