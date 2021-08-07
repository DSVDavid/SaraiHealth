using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SensorData
    {
        public int patient_id { get; set; }
        public string activity { get; set; }
        public long start { get; set; }
        public long end { get; set; }
    }
}
