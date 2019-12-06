using System;

namespace trucking_app
{
    public class TechService
    {
        public Guid ID { get; }
        public string Code { get; set; }
        public string EquipmentUnit { get; set; }
        public string Mech1 { get; set; }
        public string Mech2 { get; set; }
        public string Mech3 { get; set; }
        public string Mech4 { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public string Report { get; set; }

        public TechService()
        {
            ID = Guid.NewGuid();
        }
    }
}
