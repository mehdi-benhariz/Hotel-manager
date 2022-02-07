using System.Collections.Generic;

namespace MyAPIProject.data
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List<Hotel> Hotels { get; set; }
        // public string Code { get; set; }
        // public string Region { get; set; }
        // public int Population { get; set; }
    }
}