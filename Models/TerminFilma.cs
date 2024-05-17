using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineHub.Models;
public class TerminFilma{
    public int id { get; set; }
    public DateTime datumUra { get; set; }
    public int kapaciteta { get; set; }

    [ForeignKey("Film"), Required]
    public int filmId { get; set; }

    [ForeignKey("Dvorana"), Required]
    public int dvoranaId { get; set; }

}