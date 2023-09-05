using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Entities;

namespace WpfApp1.Reps
{
    public class OwnerReposotory
    {
        private AppContext _db;
        public OwnerReposotory(AppContext db)
        {
            _db = db;
        }
        public void Create(Owner owner)
        {
            _db.Owners.Add(owner);
            _db.SaveChanges();
        }
    }
}
