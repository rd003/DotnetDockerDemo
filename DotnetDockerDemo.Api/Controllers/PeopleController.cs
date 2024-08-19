using DotnetDockerDemo.Api.Models;
using DotnetDockerDemo.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotnetDockerDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PeopleController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            try
            {
                IEnumerable<Person> people = await _personRepository.GetPeopleAsync();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
