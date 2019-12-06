using System;

namespace trucking_app
{
    public class Shipping
    {
        public Guid ID { get; }
        public string Auto { get; set; }
        public string Trailer { get; set; }
        public string Route { get; set; }
        public string CargoCode { get; set; }
        public string CargoClass { get; set; }
        public string CargoContent { get; set; }
        public string Container { get; set; }
        public double ContainerWeight { get; set; }
        public double GrossWeight { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Driver { get; set; }
        public string Load { get; set; }
        public string Unload { get; set; }
        public bool Urgent { get; set; }
        public string Price { get; set; }
        public string Penalty { get; set; }
        public decimal Total { get; set; }
        public string CurrentLocation { get; set; }

        public Shipping()
        {
            ID = Guid.NewGuid();
        }
    }
}
