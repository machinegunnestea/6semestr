using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace СonferenceWeb.Entities
{
    public class Talk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ConferenceId { get; set; }
        public int Participant { get; set; }
    }
}
