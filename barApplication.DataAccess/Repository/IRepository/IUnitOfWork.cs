using System;

namespace BarApplication.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }

        IBarMenuRepository BarMenu { get; }

        IOrderRepository Order { get; }


        ISP_Call SP_Call { get; }

        void Save();
    }
}