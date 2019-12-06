using System;

namespace trucking_app
{
    public class Route
    {
        public Guid ID { get; }
        public string Number { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public int TravelTime { get; set; }
        public double Distance { get; set; }
        
        public Route ()
        {
            ID = Guid.NewGuid();
        }
    }
}
