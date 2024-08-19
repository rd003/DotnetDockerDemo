using System;
using Microsoft.EntityFrameworkCore;

namespace DotnetDockerDemo.Api.Models;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {

    }

    public DbSet<Person> People { get; set; }
}
