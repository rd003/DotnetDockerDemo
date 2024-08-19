using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetDockerDemo.Api.Models;

[Table("Person")]
public class Person
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;

    public Person(string name)
    {
        Name = name;
    }
}
