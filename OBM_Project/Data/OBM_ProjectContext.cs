using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBM_Project.Models.Orcamento;

namespace OBM_Project.Data
{
    public class OBM_ProjectContext : DbContext
    {
        public OBM_ProjectContext (DbContextOptions<OBM_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<OBM_Project.Models.Orcamento.Orcamento> TB_Orcamentos { get; set; }
        public DbSet<OBM_Project.Models.Orcamento.TipoServico> TB_TipoServico { get; set; }
        public DbSet<OBM_Project.Models.Orcamento.SubTipoServico> TB_SubTipoServico { get; set; }
        public DbSet<OBM_Project.Models.Orcamento.Necessidade> TB_Necessidade { get; set; }

    }
}
