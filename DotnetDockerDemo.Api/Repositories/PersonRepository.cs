using DotnetDockerDemo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetDockerDemo.Api.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly PersonContext _context;

    public PersonRepository(PersonContext context)
    {
        _context = context;
    }
    public async Task<Person> AddPerson(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<IEnumerable<Person>> GetPeopleAsync() => await _context.People.ToListAsync();
}

public interface IPersonRepository
{
    Task<Person> AddPerson(Person person);
    Task<IEnumerable<Person>> GetPeopleAsync();
}