using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repositories;
using Repositories.E;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServicesCollectionExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddRepositoryService();
            services.AddScoped<IServices<User>, UserService>();
            services.AddScoped<IServices<Child>, ChildrenService>();
            services.AddSingleton<IDBContext, UserContext>();

        }
    }
}
