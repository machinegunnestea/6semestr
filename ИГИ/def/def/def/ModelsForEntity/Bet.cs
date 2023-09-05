using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace def.ModelsForEntity
{
    public class Bet
    {
        public int Id { get; set; }
        public string? Command { get; set; }
        public double Pay { get; set; }
        public string Name { get; set; }

    }
}
