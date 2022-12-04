using Libraries.DBClient.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.DBClient
{
    public interface IRepositoryContext
    {
        DbSet<User> Users { get; set; }
    }
}
