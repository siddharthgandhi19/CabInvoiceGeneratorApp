using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGeneratorApp
{
    public class Ride
    {
        public double distance { get; set; }
        public double time { get; set; }

        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}

