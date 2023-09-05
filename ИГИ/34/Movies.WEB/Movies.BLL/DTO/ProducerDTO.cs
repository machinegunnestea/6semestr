using Movies.DAL.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.DTO
{
    public class ProducerDTO : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Продюссер")]
        [Required(ErrorMessage = "Введите имя")]
        public string FullName { get; set; }
        [Display(Name = "Год рождения")]
        [Required(ErrorMessage = "Введите год")]
        public int YearOfBirth { get; set; }

        [Display(Name = "Место рождения")]
        [Required(ErrorMessage = "Введите место рождения")]
        public string PlaceOfBirth { get; set; }
    }
}
