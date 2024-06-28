using SozinBackNew.Models.Personal;
namespace SozinBackNew.Models.Personal;
public class Personal{
    public int Id {get; set;}
    public string Name {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public string Schedule {get; set;}
    public bool Available {get; set;}
    public string Type {get; set;}
    public bool Operative {get; set;}
}