using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repositories.E;
using Repositories.Interfaces;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ServicesCollectionExtesion
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Child>, ChildRepository>();

        }
    }
}
