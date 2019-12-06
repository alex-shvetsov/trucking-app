using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trucking_app
{
    public class LoadUnload
    {
        public Guid ID { get; }
        public string Code { get; set; }
        public string Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Executor { get; set; }
        public string RespPerson { get; set; }
        public string Mechanism { get; set; }
        public string MechanismOwner { get; set; }
        public string Method { get; set; }
        public DateTime ExpArrTime { get; set; }
        public DateTime ExpDepTime { get; set; }
        public DateTime ActArrTime { get; set; }
        public DateTime ActDepTime { get; set; }
        public int ExtraTime { get; set; }

        public LoadUnload()
        {
            ID = Guid.NewGuid();
        }
    }
}
