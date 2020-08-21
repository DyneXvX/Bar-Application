using BarApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarApplication.DataAccess.Repository.IRepository
{
    public interface IBarMenuRepository : IRepository<BarMenu>
    {
        void Update(BarMenu barMenu);
    }
}
