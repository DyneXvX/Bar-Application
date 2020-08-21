using BarApplication.DataAccess.Data;
using BarApplication.DataAccess.Repository.IRepository;

namespace BarApplication.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            BarMenu = new BarMenuRepository(_db);
            Order = new OrderRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IBarMenuRepository BarMenu { get; private set; }
        public IOrderRepository Order { get; private set; }
        public ISP_Call SP_Call { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}