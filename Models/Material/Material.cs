using SozinBackNew.Models.Material;
namespace SozinBackNew.Models.Material;
public class Material{
    public int Id {get; set;}
    public string Name {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public string Serial {get; set;}
    public bool Available {get; set;}
    public Category Category {get; set;}
    public bool Operative {get; set;}
}