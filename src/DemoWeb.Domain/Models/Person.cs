using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWeb.Domain.Models;

[Table("Persons")]
public class Person
{
    [Key]
    public int Id { get; set; }
    public string? FullName { get; set; }
    public int Age { get; set; }

    public int CityId { get; set; }

    [ForeignKey(nameof(CityId))]
    public virtual City? City { get; set; }
}
