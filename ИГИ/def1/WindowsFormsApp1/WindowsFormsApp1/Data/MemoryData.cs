using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Interface;
using WindowsFormsApp1.Repositories;


namespace WindowsFormsApp1.Data
{
    class MemoryData : IData
    {
        public IRepository<Aligator> Aligator { get; set; }
        public static IData Get()
        {
            return new MemoryData()
            {
                Aligator = new Memory(),

            };

        }
    }
}
