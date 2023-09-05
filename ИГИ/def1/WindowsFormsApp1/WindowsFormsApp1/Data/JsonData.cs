using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Interface;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1.Data
{
    class JsonData : IData
    {
        public IRepository<Aligator> Aligator { get; set; }
        public static IData Get()
        {
            return new JsonData()
            {
                Aligator = new AligRep(),

            };

        }
    }
}
