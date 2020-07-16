using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBM_Project.Models;

namespace OBM_Project.Data
{
    public class OBM_ProjectContext : DbContext
    {
        public OBM_ProjectContext (DbContextOptions<OBM_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<OBM_Project.Models.Departamento> Departamento { get; set; }
    }
}
