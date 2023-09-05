using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace def.Models
{
    public class BetForCreate
    {
        [Display(Name = "Ваше имя")]
        public string? Name { get; set; }

        [Display(Name = "Команда")]
        public string? Command { get; set; }

        [Display(Name = "Ваша ставка")]
        public double Pay { get; set; }
    }
}
