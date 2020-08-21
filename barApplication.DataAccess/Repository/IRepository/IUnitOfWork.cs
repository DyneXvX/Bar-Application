using System;

namespace BarApplication.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ISP_Call SP_Call { get; }
    }
}