using NUnit.Framework;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Interface;
using WindowsFormsApp1.Repositories;

namespace TestProject1
{
    public class Tests
    {
        private IRepository<Aligator> repository = new AligRep();

        [Test, Order(1)]
        public void AddData()
        {
            try
            {
                //Arrange
                Aligator crocodile = new Aligator()
                {

                    Name = "PAcagw",
                    Height = 89,
                    Weight = 90
                };
                bool actual = repository.Create(crocodile);
                Assert.AreEqual(actual, true);
            }
            catch
            {
                Assert.Fail();
            }

        }

        [Test, Order(2)]
        public void DeleteData()

        {
            bool actual = repository.Delete("PAcagw");
            Assert.AreEqual(actual, true);
        }
    }
}