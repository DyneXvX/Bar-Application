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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Order order)
        {
            var objFromDb = _db.Orders.FirstOrDefault(s => s.Id == order.Id);
            if (objFromDb != null)
            {
                objFromDb.MenuId = order.MenuId;
                objFromDb.QuantityOfDrink = order.QuantityOfDrink;
                objFromDb.TableNumber = order.TableNumber;
                _db.SaveChanges();
            }
        }

    }
}
