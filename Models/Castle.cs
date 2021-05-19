using System.ComponentModel.DataAnnotations;

namespace AKnightsTale.Models
{
  public class Castle
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
  }
}