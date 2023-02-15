using Repositories.E;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class UserService : IServices<User>
    {
        
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> AddAsync(User entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
           await _repository.DeleteAsync(id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _repository.GetAllUsAsync();
        }

        public async Task<User> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
