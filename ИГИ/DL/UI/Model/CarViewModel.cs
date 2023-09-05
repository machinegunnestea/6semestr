using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.DTO;

namespace UI.Model
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Cost { get; set; }
        public string CarTypeTitle { get; set; }
        public CarViewModel(CarDTO carDTO,CarTypeDTO carTypeDTO) 
        {
            Id = carDTO.Id;
            Title= carDTO.Title;
            Cost= carDTO.Cost;
            CarTypeTitle = carTypeDTO.Title;
        }
        public static List<CarViewModel> CreateList(List<CarDTO> carDTOs, List<CarTypeDTO> carTypeDTOs)
        {
            List<CarViewModel> carViewModels = new();
            carDTOs.ForEach(x =>
            {
                carViewModels
                    .Add(new CarViewModel(x, carTypeDTOs.FirstOrDefault(type => type.Id == x.CarTypeId)));
            });
            return carViewModels;
        }
    }
}
