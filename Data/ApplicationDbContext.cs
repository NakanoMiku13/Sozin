using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SozinBackNew.Models.Material;
using SozinBackNew.Models.Machinery;
using SozinBackNew.Models.Personal;
using SozinBackNew.Models.Logs;
using SozinBackNew.Models;
using SozinBackNew.Models.Users;
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
        public DbSet<Personal> Personal {get; set;}
        public DbSet<PersonalIncident> PersonalIncident {get; set;}
        public DbSet<UserApp> UsersApp {get; set;}
        public DbSet<operationlog> operationlog {get; set;}
        public DbSet<operationlogrecord> operationlogrecord {get; set;}
        public DbSet<resourceslog> resourceslog {get; set;}
        public DbSet<resourceslogrecord> resourceslogrecord {get; set;}
    }
}