using SozinBackNew.Models.Material;
namespace SozinBackNew.Models.Material;
public class MaterialIncident{
    public int Id {get; set;}
    public Material Material {get; set;}
    public int IncidentId {get; set;}
}