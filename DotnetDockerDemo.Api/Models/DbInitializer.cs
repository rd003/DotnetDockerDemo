using Microsoft.EntityFrameworkCore;

namespace DotnetDockerDemo.Api.Models;

public class DbInitializer : IDbInitializer
{
    private readonly PersonContext _context;

    public DbInitializer(PersonContext context)
    {
        _context = context;
    }
    private static List<Person> people = [
              new Person ("John"),
              new Person ("Max"),
              new Person ("Jill"),
              new Person ("Ken"),
              ];

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();
            if (await _context.People.AnyAsync())
            {
                return;
            }
            _context.People.AddRange(people);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public interface IDbInitializer
{
    Task InitializeAsync();
}