using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trucking_app
{
    public class Position
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Duties { get; set; }

        public Position()
        {
            ID = Guid.NewGuid();
        }
    }
}
