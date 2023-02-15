using Repositories.E;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class ChildrenService : IServices<Child>
    {
        private readonly IRepository<Child> _repository;
        public ChildrenService(IRepository<Child> repository)
        {
            _repository = repository;
        }

        public async Task<Child> AddAsync(Child entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("delete");
            await _repository.DeleteAsync(id);
        }

        public async Task<List<Child>> GetAllAsync()
        {
            
            return await _repository.GetAllUsAsync();
        }

        public async Task<Child> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Child> UpdateAsync(Child entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
