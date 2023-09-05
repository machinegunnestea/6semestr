using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    public class Aligator
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Height")]
        public int Height { get; set; }

        [JsonProperty("Weight")]
        public int Weight { get; set; }

        public Aligator()
        {
        }

        public Aligator(string name, int weight, int height)
        {
            this.Name = name;
            this.Weight = weight;
            this.Height = height;
        }
    }
}
