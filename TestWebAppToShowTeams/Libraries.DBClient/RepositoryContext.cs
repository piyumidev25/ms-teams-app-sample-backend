using Libraries.DBClient.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.DBClient
{
    public class RepositoryContext: DbContext, IRepositoryContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
}
}
