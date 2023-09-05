using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace СonferenceWeb.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public string ConferenceName { get; set; }
        public string Organizers { get; set; }
        public string Sponsors { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CoffeeBrake { get; set; }
        public DateTime Banket { get; set; }
        public List<Members> Members { get; set; }
    }
}
