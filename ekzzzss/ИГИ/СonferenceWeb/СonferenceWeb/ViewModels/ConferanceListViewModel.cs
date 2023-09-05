using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using СonferenceWeb.Entities;

namespace СonferenceWeb.ViewModels
{
    public class ConferanceListViewModel
    {
        public IEnumerable<Conference> Conferences { get; set; }
        public List<Talk>? Talk { get; set; }
        public Conference? Conference { get; set; }
        public List<Members> Members { get; set; }
    }
}
