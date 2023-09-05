using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace def.ModelsForEntity
{
    public class FightCommand
    {
        public int Id { get; set; }
        [Display(Name = "Время встречи")]
        public DateTime Date { get; set; }
        [Display(Name = "Команда 1")]
        public string? CommandOne { get; set; }
        [Display(Name = "Команда 2")]
        public string? CommandTwo { get; set; }
    }
}
