using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trucking_app
{
    public class Branch
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Branch ()
        {
            ID = Guid.NewGuid();
        }
    }
}
