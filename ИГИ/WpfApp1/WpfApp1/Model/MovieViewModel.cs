using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;

namespace UI.Model
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Cost { get; set; }
        public string MovieTypeTitle { get; set; }
        public MovieViewModel(MovieDTO movieDTO, MovieTypeDTO movieTypeDTO) 
        {
            Id = movieDTO.Id;
            Title= movieDTO.Title;
            Cost= movieDTO.Cost;
            MovieTypeTitle = movieTypeDTO.Title;
        }
        public static List<MovieViewModel> CreateList(List<MovieDTO> movieDTOs, List<MovieTypeDTO> movieTypeDTOs)
        {
            List<MovieViewModel> movieViewModels = new();
            movieDTOs.ForEach(x =>
            {
                movieViewModels
                    .Add(new MovieViewModel(x, movieTypeDTOs.FirstOrDefault(type => type.Id == x.MovieTypeId)));
            });
            return movieViewModels;
        }
    }
}
