using System;
using SozinBackNew.Models.Logs;
namespace SozinBackNew.Models.Logs;
public class operationlogrecord{
    public int id {get; set;}
    public int original_record {get; set;}
    public string name {get; set;}
    public DateTime date {get; set;}
    public string notes {get; set;}
    public int incident_id {get; set;}
    public int person_id {get; set;}
    public string assigned_tasks {get; set;} = "Nothing";
    public int worked_hours {get; set;} = 0;
    public int crew_id {get; set;} = 1;
}