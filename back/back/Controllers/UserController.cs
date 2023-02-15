using Microsoft.AspNetCore.Mvc;
using Repositories.E;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServices<User> _services;
        public UserController(IServices<User> services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<User>> Get()
        {
            return _services.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            return _services.GetAsync(id);
        }

        [HttpPost]
        public Task Post([FromBody] User user)
        {
            return _services.AddAsync(user);
        }

        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] User user)
        {
           return _services.UpdateAsync(user);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
           return _services.DeleteAsync(id);
        }
    }
}
