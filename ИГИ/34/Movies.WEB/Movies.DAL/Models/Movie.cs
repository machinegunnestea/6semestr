using Movies.DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public string Tagline { get; set; }
        public double Budget { get; set; }
        public double Price { get; set; }
        public double Duration { get; set; }


        //Relationships
        //Producer
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        //Screenwriter
        public int ScreenwriterId { get; set; }
        public Screenwriter Screenwriter { get; set; }
    }
}
