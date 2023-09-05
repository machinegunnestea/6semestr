using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entities;

namespace WpfApp1.Reps
{
    public class CatRepository
    {
        private AppContext _db;
        public CatRepository(AppContext db)
        {
            _db = db;
        }
        public void Create(Cat cat)
        {
            _db.Cats.Add(cat);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            Cat cat = _db.Cats.Find(id);
            Delete(cat.Id);
            _db.SaveChanges();
        }
        //вывод всех
        public List<Cat> GetAll() => _db.Cats.Include(c => c.Owner).ToList();
      
        //поиск по кличке
        public Cat GetT(string name) => (Cat)_db.Cats.Where(c => c.Name == name);

        //поиск по возрасту
        public Cat GetT(int age) => (Cat)_db.Cats.Where(c => c.Age == age);

        //поиск по фамилии владельца
        public Cat GetTOwner(string lastname) => (Cat)_db.Cats.Where(c => c.Owner.Lastname == lastname);
    }
}
