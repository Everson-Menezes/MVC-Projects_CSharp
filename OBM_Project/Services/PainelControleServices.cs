using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OBM_Project.Data;
using OBM_Project.Models.Orcamento;

namespace OBM_Project.Services
{
    public class PainelControleServices
    {
        private readonly OBM_ProjectContext _ProjectContext;

        public PainelControleServices(OBM_ProjectContext projectContext)
        {
            _ProjectContext = projectContext;
        }
        public List<TipoServico> ListarTipoServicos()
        {
            return _ProjectContext.TB_TipoServico.OrderBy(x => x.Nome).ToList();
        }
        public List<SubTipoServico> ListarSubTipoServicos()
        {
            return _ProjectContext.TB_SubTipoServico.ToList();
        }
        public List<Necessidade> ListarNecessidade()
        {
            return _ProjectContext.TB_Necessidade.ToList();
        }
        public List<Orcamento> ListarOrcamentos()
        {
            return _ProjectContext.TB_Orcamentos.ToList();
        }
        public void AdicionarTipoServico(TipoServico obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarSubTipoServico(SubTipoServico obj)
        {
            _ProjectContext.Add(obj);
            var teste = obj;
            _ProjectContext.SaveChanges();
        }
    }
}
