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
    internal class UserRepository : IRepository<User>
    {
        IDBContext dbContext;
        public UserRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> AddAsync(User entity)
        {
            if (!(dbContext.Users.Any(u => u.UserId == entity.UserId)))
            {
                var user = dbContext.Users.Add(entity);
                await dbContext.SaveChangesAsync();
                return user.Entity;
            }
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            dbContext.Users.Remove(dbContext.Users.FirstOrDefault(u => u.UserId == id));
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var user = dbContext.Users.Update(entity);
            await dbContext.SaveChangesAsync();
            return user.Entity;
        }
    }
}
