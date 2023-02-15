using Microsoft.EntityFrameworkCore;
using Repositories.E;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    internal class ChildRepository : IRepository<Child>
    {

        IDBContext dbContext;
        public ChildRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Child> AddAsync(Child entity)
        {
            if(!(dbContext.Children.Any(c=>c.ChildId==entity.ChildId)))
            { 
            var user = dbContext.Children.Add(entity);
            await dbContext.SaveChangesAsync();
            return user.Entity;
            }
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("repository");
            dbContext.Children.Remove(dbContext.Children.FirstOrDefault(u => u.ChildId== id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Child>> GetAllUsAsync()
        {
            return await dbContext.Children.ToListAsync();
        }

        public async Task<Child> GetAsync(int id)
        {
            return await dbContext.Children.FindAsync(id);
        }

        public async Task<Child> UpdateAsync(Child entity)
        {
            var child = dbContext.Children.Update(entity);
            await dbContext.SaveChangesAsync();
            return child.Entity;
        }
    }
}
