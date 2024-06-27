using SozinBackNew.Models.Machinery;
namespace SozinBackNew.Models.Machinery;
public class MachineryIncident{
    public int Id {get; set;}
    public Machinery Machinery {get; set;}
    public int IncidentId {get; set;}
}