using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace OBM_Project.Data
{
    public class SeedingServices
    {
        private OBM_ProjectContext _ProjectContext;
        public SeedingServices(OBM_ProjectContext projectContext)
        {
            _ProjectContext = projectContext;
        }
        public void Seed()
        {
            if (_ProjectContext.TB_TipoServico.Any() || _ProjectContext.TB_SubTipoServico.Any() || _ProjectContext.TB_Orcamentos.Any() || _ProjectContext.TB_Necessidade.Any())
            {
                return; 
            }
            else
            {
                _ProjectContext.TB_TipoServico.AddRange();
                _ProjectContext.TB_SubTipoServico.AddRange();
                _ProjectContext.TB_Necessidade.AddRange();
                _ProjectContext.TB_Orcamentos.AddRange();
            }
            _ProjectContext.SaveChanges();
        }
    }
}
