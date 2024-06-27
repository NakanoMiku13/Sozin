using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SozinBackNew.Models.Material;
using SozinBackNew.Models.Machinery;
using SozinBackNew.Models;
namespace SozinBackNew.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Incident> incident {get; set;}
        public DbSet<SozinBackNew.Models.Material.Category> MaterialCategories {get; set;}
        public DbSet<Material> Materials {get; set;}
        public DbSet<MaterialIncident> MaterialsPerIncident {get; set;}
        public DbSet<SozinBackNew.Models.Machinery.Category> MachineryCategories {get; set;}
        public DbSet<Machinery> Machineries {get; set;}
        public DbSet<MachineryIncident> MachineriesPerIncident {get; set;}
        
    }
}