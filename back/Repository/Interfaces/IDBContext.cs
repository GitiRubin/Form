using Microsoft.EntityFrameworkCore;
using Repositories.E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IDBContext
    {
        public DbSet<Child> Children { get; set; }

        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
