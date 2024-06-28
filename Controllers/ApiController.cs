using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SozinBackNew.Models.Machinery;
using SozinBackNew.Models.Material;
using SozinBackNew.Models.Personal;
using SozinBackNew.Data;
using Microsoft.EntityFrameworkCore;
namespace SozinBackNew.Controllers;
[Route("v1/")]
//[AllowAnonymous]
public class ApiController : ControllerBase
{
    private readonly ILogger<ApiController> _logger;
    private readonly ApplicationDbContext _applicationDbContext;

    public ApiController(ILogger<ApiController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _applicationDbContext = applicationDbContext;
    }
    
    [HttpGet]
    [Route("Get/Machinery/Categories")]
    public async Task<IActionResult> GetMachineryCategories(){
        try{
            return Ok(await _applicationDbContext.MachineryCategories.ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Material/Categories")]
    public async Task<IActionResult> GetMaterialCategories(){
        try{
            return Ok(await _applicationDbContext.MaterialCategories.ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Materials/By/Categories")]
    public async Task<IActionResult> GetMaterialByCategories(int id){
        try{
            return Ok(await _applicationDbContext.Materials.Include(p => p.Category)
            .Where(p => p.Category.Id == id).ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Machinery/By/Categories")]
    public async Task<IActionResult> GetMachineryByCategories(int id){
        try{
            return Ok(await _applicationDbContext.Machineries.Include(p => p.Category)
            .Where(p => p.Category.Id == id).ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Materials")]
    public async Task<IActionResult> GetMaterial(){
        try{
            return Ok(await _applicationDbContext.Materials.ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Personal")]
    public async Task<IActionResult> GetPersonal(){
        try{
            return Ok(await _applicationDbContext.Personal.ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Machineries")]
    public async Task<IActionResult> GetMachinery(){
        try{
            return Ok(await _applicationDbContext.Machineries.ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Materials/By/Id")]
    public async Task<IActionResult> GetMaterial(int id){
        try{
            return Ok(await _applicationDbContext.Materials.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id));
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Personal/By/Id")]
    public async Task<IActionResult> GetPersonalById(int id){
        try{
            return Ok(await _applicationDbContext.Personal.FirstOrDefaultAsync(p => p.Id == id));
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Machineries/By/Id")]
    public async Task<IActionResult> GetMachinery(int id){
        try{
            return Ok(await _applicationDbContext.Machineries.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id));
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Set/Machinery/Category")]
    public async Task<IActionResult> SetMachineryCategory(string Name, string Type){
        try{
            var category = await _applicationDbContext.MachineryCategories.FirstOrDefaultAsync(p => p.Name.ToLower() == Name.ToLower());
            if (category == null){
                await _applicationDbContext.MachineryCategories.AddAsync(new(){Name= Name, Type=Type});
            }else{
                category.Name = Name;
                category.Type = Type;
                _applicationDbContext.MachineryCategories.Update(category);
            }
            await _applicationDbContext.SaveChangesAsync();
            return Created();
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Set/Material/Category")]
    public async Task<IActionResult> SetMaterialCategory(string Name, string Type){
        try{
            var category = await _applicationDbContext.MaterialCategories.FirstOrDefaultAsync(p => p.Name.ToLower() == Name.ToLower());
            if (category == null){
                await _applicationDbContext.MaterialCategories.AddAsync(new(){Name= Name, Type= Type});
            }else{
                category.Name = Name;
                category.Type = Type;
                _applicationDbContext.MaterialCategories.Update(category);
            }
            await _applicationDbContext.SaveChangesAsync();
            return Created();
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Set/Machinery")]
    public async Task<IActionResult> SetMachinery([FromBody] MachineryRequest machinery){
        try{
            var machineryOld = await _applicationDbContext.Machineries.FirstOrDefaultAsync(p => p.Name.ToLower() == machinery.Name.ToLower());
            Console.WriteLine(machinery.CategoryId);
            var category = await _applicationDbContext.MachineryCategories.FirstOrDefaultAsync(p => p.Id == machinery.CategoryId);
            if(category == null) return BadRequest("No category found");
            if (machineryOld == null){
                Machinery newMachinery = new(){
                    Name = machinery.Name,
                    Latitude = machinery.Latitude,
                    Longitude = machinery.Longitude,
                    Serial = machinery.Serial,
                    Available = machinery.Available,
                    Category = category,
                    Operative = machinery.Operative
                };
                await _applicationDbContext.Machineries.AddAsync(newMachinery);
            }else{
                machineryOld.Name = machinery.Name;
                machineryOld.Latitude = machinery.Latitude;
                machineryOld.Longitude = machinery.Longitude;
                machineryOld.Serial = machinery.Serial;
                machineryOld.Available = machinery.Available;
                machineryOld.Category = category;
                machineryOld.Operative = machinery.Operative;
                _applicationDbContext.Machineries.Update(machineryOld);
            }
            await _applicationDbContext.SaveChangesAsync();
            return Created();
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Set/Personal")]
    public async Task<IActionResult> SetPersonal([FromBody] PersonalRequest personal){
        try{
            var personalOld = await _applicationDbContext.Personal.FirstOrDefaultAsync(p => p.Name.ToLower() == personal.Name.ToLower());
            if (personalOld == null){
                Personal newPersonal = new(){
                    Name = personal.Name,
                    Latitude = personal.Latitude,
                    Longitude = personal.Longitude,
                    Schedule = personal.Schedule,
                    Available = personal.Available,
                    Operative = personal.Operative,
                    Type = personal.Type
                };
                await _applicationDbContext.Personal.AddAsync(newPersonal);
            }else{
                personalOld.Name = personal.Name;
                personalOld.Latitude = personal.Latitude;
                personalOld.Longitude = personal.Longitude;
                personalOld.Schedule = personal.Schedule;
                personalOld.Available = personal.Available;
                personalOld.Operative = personal.Operative;
                personalOld.Type = personal.Type;
                _applicationDbContext.Personal.Update(personalOld);
            }
            await _applicationDbContext.SaveChangesAsync();
            return Created();
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Set/Material")]
    public async Task<IActionResult> SetMaterial([FromBody] MaterialRequest Material){
        try{
            var MaterialOld = await _applicationDbContext.Materials.FirstOrDefaultAsync(p => p.Name.ToLower() == Material.Name.ToLower());
            var category = await _applicationDbContext.MaterialCategories.FirstOrDefaultAsync(p => p.Id == Material.CategoryId);
            if(category == null) return BadRequest("No category found");
            if (MaterialOld == null){
                Material newMaterial = new(){
                    Name = Material.Name,
                    Latitude = Material.Latitude,
                    Longitude = Material.Longitude,
                    Serial = Material.Serial,
                    Available = Material.Available,
                    Category = category,
                    Operative = Material.Operative
                };
                await _applicationDbContext.Materials.AddAsync(newMaterial);
            }else{
                MaterialOld.Name = Material.Name;
                MaterialOld.Latitude = Material.Latitude;
                MaterialOld.Longitude = Material.Longitude;
                MaterialOld.Serial = Material.Serial;
                MaterialOld.Available = Material.Available;
                MaterialOld.Category = category;
                MaterialOld.Operative = Material.Operative;
                _applicationDbContext.Materials.Update(MaterialOld);
            }
            await _applicationDbContext.SaveChangesAsync();
            return Created();
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Assign/Material/Incident")]
    public async Task<IActionResult> AssignMaterial(int materialId, int incidentId){
        try{
            var material = await _applicationDbContext.Materials.FirstOrDefaultAsync(p => p.Id == materialId);
            if(material == null) return BadRequest("Material not found");
            var incidentPrev = await _applicationDbContext.MaterialsPerIncident.Include(p => p.Material).FirstOrDefaultAsync(p => p.Material.Id == materialId);
            if(incidentPrev != null) return BadRequest("Material previously assigned");
            var incident = await _applicationDbContext.incident.FirstOrDefaultAsync(p => p.Id == incidentId);
            if(incident == null) return BadRequest("Incident not found");
            MaterialIncident incidentMaterial = new(){
                Material = material,
                IncidentId = incidentId
            };
            await _applicationDbContext.MaterialsPerIncident.AddAsync(incidentMaterial);
            await _applicationDbContext.SaveChangesAsync();
            material.Available = false;
            _applicationDbContext.Materials.Update(material);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(incidentMaterial);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Assign/Personal/Incident")]
    public async Task<IActionResult> AssignPersonal(int personalId, int incidentId){
        try{
            var material = await _applicationDbContext.Personal.FirstOrDefaultAsync(p => p.Id == personalId);
            if(material == null) return BadRequest("Material not found");
            var incidentPrev = await _applicationDbContext.PersonalIncident.Include(p => p.Personal).FirstOrDefaultAsync(p => p.Personal.Id == personalId);
            if(incidentPrev != null) return BadRequest("Material previously assigned");
            var incident = await _applicationDbContext.incident.FirstOrDefaultAsync(p => p.Id == incidentId);
            if(incident == null) return BadRequest("Incident not found");
            PersonalIncident incidentMaterial = new(){
                Personal = material,
                IncidentId = incidentId
            };
            await _applicationDbContext.PersonalIncident.AddAsync(incidentMaterial);
            await _applicationDbContext.SaveChangesAsync();
            material.Available = false;
            _applicationDbContext.Personal.Update(material);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(incidentMaterial);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Assign/Materials/Incident")]
    public async Task<IActionResult> AssignedMaterials(int id){
        try{
            return Ok(await _applicationDbContext.MaterialsPerIncident.Include(p => p.Material).Where(p => p.IncidentId == id).ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Assign/Personal/Incident")]
    public async Task<IActionResult> AssignedPersonal(int id){
        try{
            return Ok(await _applicationDbContext.PersonalIncident.Include(p => p.Personal).Where(p => p.IncidentId == id).ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("Get/Assign/Machineries/Incident")]
    public async Task<IActionResult> AssignedMachineries(int id){
        try{
            return Ok(await _applicationDbContext.MachineriesPerIncident.Include(p => p.Machinery).Where(p => p.IncidentId == id).ToListAsync());
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Assign/Machinery/Incident")]
    public async Task<IActionResult> AssignMachinery(int MachineryId, int incidentId){
        try{
            var Machinery = await _applicationDbContext.Machineries.FirstOrDefaultAsync(p => p.Id == MachineryId);
            if(Machinery == null) return BadRequest("Machinery not found");
            var incidentPrev = await _applicationDbContext.MachineriesPerIncident.Include(p => p.Machinery).FirstOrDefaultAsync(p => p.Machinery.Id == MachineryId);
            if(incidentPrev != null) return BadRequest("Machinery previously assigned");
            var incident = await _applicationDbContext.incident.FirstOrDefaultAsync(p => p.Id == incidentId);
            if(incident == null) return BadRequest("Incident not found");
            MachineryIncident incidentMachinery = new(){
                Machinery = Machinery,
                IncidentId = incidentId
            };
            await _applicationDbContext.MachineriesPerIncident.AddAsync(incidentMachinery);
            await _applicationDbContext.SaveChangesAsync();
            Machinery.Available = false;
            _applicationDbContext.Machineries.Update(Machinery);
            await _applicationDbContext.SaveChangesAsync();
            return Ok(incidentMachinery);
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("Deassigned/Machinery/Incident")]
    public async Task<IActionResult> DeassignMachinery(int MachineryId, int incidentId){
        try{
            var incident = await _applicationDbContext.incident.FirstOrDefaultAsync(p => p.Id == incidentId);
            if(incident == null) return BadRequest("Incident not found");
            var Machinery = await _applicationDbContext.Machineries.FirstOrDefaultAsync(p => p.Id == MachineryId);
            if(Machinery == null) return BadRequest("Machinery not found");
            var incidentPrev = await _applicationDbContext.MachineriesPerIncident.Include(p => p.Machinery).FirstOrDefaultAsync(p => p.Machinery.Id == MachineryId && p.IncidentId == incidentId);
            if(incidentPrev == null) return BadRequest("Machinery not previously assigned");
            _applicationDbContext.MachineriesPerIncident.Remove(incidentPrev);
            await _applicationDbContext.SaveChangesAsync();
            Machinery.Available = true;
            _applicationDbContext.Machineries.Update(Machinery);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Deassigned");
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("Deassigned/Personal/Incident")]
    public async Task<IActionResult> DeassignPersonal(int PersonalId, int incidentId){
        try{
            var incident = await _applicationDbContext.incident.FirstOrDefaultAsync(p => p.Id == incidentId);
            if(incident == null) return BadRequest("Incident not found");
            var Machinery = await _applicationDbContext.Personal.FirstOrDefaultAsync(p => p.Id == PersonalId);
            if(Machinery == null) return BadRequest("Machinery not found");
            var incidentPrev = await _applicationDbContext.PersonalIncident.Include(p => p.Personal).FirstOrDefaultAsync(p => p.Personal.Id == PersonalId && p.IncidentId == incidentId);
            if(incidentPrev == null) return BadRequest("Machinery not previously assigned");
            _applicationDbContext.PersonalIncident.Remove(incidentPrev);
            await _applicationDbContext.SaveChangesAsync();
            Machinery.Available = true;
            _applicationDbContext.Personal.Update(Machinery);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Deassigned");
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("Deassigned/Material/Incident")]
    public async Task<IActionResult> DeassignMaterial(int MaterialId, int incidentId){
        try{
            var incident = await _applicationDbContext.incident.FirstOrDefaultAsync(p => p.Id == incidentId);
            if(incident == null) return BadRequest("Incident not found");
            var Material = await _applicationDbContext.Materials.FirstOrDefaultAsync(p => p.Id == MaterialId);
            if(Material == null) return BadRequest("Material not found");
            var incidentPrev = await _applicationDbContext.MaterialsPerIncident.Include(p => p.Material).FirstOrDefaultAsync(p => p.Material.Id == MaterialId && p.IncidentId == incidentId);
            if(incidentPrev == null) return BadRequest("Material not previously assigned");
            _applicationDbContext.MaterialsPerIncident.Remove(incidentPrev);
            await _applicationDbContext.SaveChangesAsync();
            Material.Available = false;
            _applicationDbContext.Materials.Update(Material);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Deassigned");
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("Delete/Machinery")]
    public async Task<IActionResult> DeleteMachinery(int id){
        try{
            var machineryOld = await _applicationDbContext.Machineries.FirstOrDefaultAsync(p => p.Id == id);
            if(machineryOld == null) return BadRequest("Machinery Not found");
            _applicationDbContext.Machineries.Remove(machineryOld);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Removed");
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("Delete/Material")]
    public async Task<IActionResult> DeleteMaterial(int id){
        try{
            var MaterialOld = await _applicationDbContext.Materials.FirstOrDefaultAsync(p => p.Id == id);
            if(MaterialOld == null) return BadRequest("Material Not found");
            _applicationDbContext.Materials.Remove(MaterialOld);
            await _applicationDbContext.SaveChangesAsync();
            return Ok("Removed");
        }catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
}
public class MachineryRequest{
    public int? Id {get; set;}
    public string Name {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public string Serial {get; set;}
    public bool Available {get; set;}
    public int CategoryId {get; set;}
    public bool Operative {get; set;}
}
public class PersonalRequest{
    public int? Id {get; set;}
    public string Name {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public string Schedule {get; set;}
    public bool Available {get; set;}
    public bool Operative {get; set;}
    public string Type {get; set;}
}
public class MaterialRequest{
    public int? Id {get; set;}
    public string Name {get; set;}
    public double Latitude {get; set;}
    public double Longitude {get; set;}
    public string Serial {get; set;}
    public bool Available {get; set;}
    public int CategoryId {get; set;}
    public bool Operative {get; set;}
}