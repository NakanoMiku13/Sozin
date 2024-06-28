using SozinBackNew.Models.Personal;
namespace SozinBackNew.Models.Personal;
public class PersonalIncident{
    public int Id {get; set;}
    public Personal Personal {get; set;}
    public int IncidentId {get; set;}
}