using System;
using SozinBackNew.Models.Logs;
namespace SozinBackNew.Models.Logs;
public class resourceslog{
    public int id {get; set;}
    public string name {get; set;}
    public DateTime date {get; set;}
    public string notes {get; set;}
    public int incident_id {get; set;}
    public int person_id {get; set;}
}