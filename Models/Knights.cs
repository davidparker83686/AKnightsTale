using System.ComponentModel.DataAnnotations;

namespace AKnightsTale.Models
{
  public class Knight
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Castle { get; set; }
    public bool Good { get; set; }
    public bool Evil { get; set; }
  }
}