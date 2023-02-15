using Microsoft.AspNetCore.Mvc;
using Repositories.E;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private readonly IServices<Child> _services;
        public ChildrenController(IServices<Child> services)
        {
            _services = services;
        }

        [HttpGet]
        public Task<List<Child>> Get()
        {
            return _services.GetAllAsync();
        }

        [HttpGet("{id}")]
        public Task<Child> Get(int id)
        {
            return _services.GetAsync(id);
        }

        [HttpPost]
        public Task Post([FromBody] Child Child)
        {
            Console.WriteLine();
            return _services.AddAsync(Child);
        }

        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] Child Child)
        {
            return _services.UpdateAsync(Child);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            Console.WriteLine("controller");
            return _services.DeleteAsync(id);
        }
    }
}
