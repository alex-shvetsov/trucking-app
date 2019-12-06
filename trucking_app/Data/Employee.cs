using System;

namespace trucking_app
{
    public class Employee
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string Position { get; set; }
        public string Branch { get; set; }

        public Employee()
        {
            ID = Guid.NewGuid();
        }
    }
}
