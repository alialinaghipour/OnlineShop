using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Application
{
    public interface UnitOfWork:IDisposable
    {
        void Complate();
        Task ComplateAysnc();
    }
}
