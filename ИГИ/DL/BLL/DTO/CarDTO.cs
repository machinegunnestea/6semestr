using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ВLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public double Cost { get; set; }
        public int CarTypeId { get; set; }

    }
}
