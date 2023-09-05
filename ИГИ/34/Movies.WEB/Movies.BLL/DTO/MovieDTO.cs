using Movies.DAL.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.DTO
{
    public class MovieDTO : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Фильм")]
        [Required(ErrorMessage = "Введите название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }

        [Display(Name = "Год выхода")]
        [Required(ErrorMessage = "Введите год")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Страна происхождения")]
        [Required(ErrorMessage = "Введите страну происхождения")]
        public string Country { get; set; }

        [Display(Name = "Слоган")]
        [Required(ErrorMessage = "Введите слоган")]
        public string Tagline { get; set; }

        [Display(Name = "Бюджет")]
        [Required(ErrorMessage = "Введите бюджет")]
        public double Budget { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Введите цену")]
        public double Price { get; set; }

        [Display(Name = "Длительность фильма")]
        [Required(ErrorMessage = "Введите длительность фильма")]
        public double Duration { get; set; }

        //Producer
        [Display(Name = "Продюссер")]
        [Required(ErrorMessage = "Выберете продюссера(ов)")]
        public int ProducerId { get; set; }

        //Screenwriter
        [Display(Name = "Сценарист")]
        [Required(ErrorMessage = "Выберете сценариста(ов)")]
        public int ScreenwriterId { get; set; }
    }
}
