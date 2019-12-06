using System;

namespace trucking_app
{
    public class Equipment
    {
        public Guid ID { get; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string TrailerType { get; set; }
        public string Number { get; set; }
        public string Dim { get; set; }
        public double WeightCapacity { get; set; }
        public double VolumeCapacity { get; set; }
        public string EngineType { get; set; }
        public double Mass { get; set; }
        public decimal Price { get; set; }

        public Equipment()
        {
            ID = Guid.NewGuid();
        }
    }
}
