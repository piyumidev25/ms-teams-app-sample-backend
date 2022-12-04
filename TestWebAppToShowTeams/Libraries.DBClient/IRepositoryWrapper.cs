using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraries.DBClient
{
    public interface IRepositoryWrapper
    {
        IAADUserRepository AADUserRepository { get; }
        Task SaveAsync();
    }
}
