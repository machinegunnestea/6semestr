﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MovieType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        ICollection<Movie> movies { get; set; }
    }
}
