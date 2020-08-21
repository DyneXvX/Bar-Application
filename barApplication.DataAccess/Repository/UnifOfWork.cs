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
            SP_Call = new SP_Call(_db);
        }

        public ISP_Call SP_Call { get; }

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