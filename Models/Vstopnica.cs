using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineHub.Models;
public class Vstopnica{
    public int id { get; set; }
    public int stVstopnic { get; set; }
    public Boolean kupljena { get; set; }

    [ForeignKey("TerminFilma"), Required]
    public int terminFilmaId { get; set; }
    public ApplicationUser? UserId { get; set; }

}