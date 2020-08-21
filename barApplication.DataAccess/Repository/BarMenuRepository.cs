using BarApplication.DataAccess.Data;
using BarApplication.DataAccess.Repository.IRepository;
using BarApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarApplication.DataAccess.Repository
{
    public class BarMenuRepository : Repository<BarMenu>, IBarMenuRepository
    {
        private readonly ApplicationDbContext _db;

        public BarMenuRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BarMenu barMenu)
        {
            var objFromDb = _db.BarMenu.FirstOrDefault(s => s.Id == barMenu.Id);
            if (objFromDb != null)
            {
                objFromDb.DrinkName = barMenu.DrinkName;
                objFromDb.Price = barMenu.Price;
                objFromDb.Quantity = barMenu.Quantity;
                _db.SaveChanges();
            }

            
        }
    }
}
