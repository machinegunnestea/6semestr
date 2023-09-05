using Movies.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Models
{
    public class Producer : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int YearOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }

    }
}
