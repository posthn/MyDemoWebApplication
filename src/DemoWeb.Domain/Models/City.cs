using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWeb.Domain.Models;

[Table("Cities")]
public class City
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Person> Persons { get; set; }

    public City() => Persons = new List<Person>();
}
