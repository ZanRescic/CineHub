using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineHub.Models;
public class Sedez{
    public int id { get; set; }
    public int vrsta { get; set; }
    public int stevilka { get; set; }
    
    [ForeignKey("Dvorana"), Required]
    public int dvoranaId { get; set; }
}