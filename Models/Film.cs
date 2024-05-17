namespace CineHub.Models;
public class Film{
    public int id { get; set; }
    public required string naslov { get; set; }
    public int dolzina { get; set; }
    public required string zanr { get; set; }
    public required string vrstaVsebine { get; set; }
    public int ocena { get; set; }
}