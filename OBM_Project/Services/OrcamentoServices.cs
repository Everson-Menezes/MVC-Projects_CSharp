using OBM_Project.Data;
using OBM_Project.Models.Orcamento;
using System.Collections.Generic;
using System.Linq;

namespace OBM_Project.Services
{
    public class OrcamentoServices
    {
        private readonly OBM_ProjectContext _ProjectContext;

        public OrcamentoServices(OBM_ProjectContext projectContext)
        {
            _ProjectContext = projectContext;
        }

        public void AdicionarOrcamento(Orcamentos obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }

        public List<TipoServico> ListarTipoServicos()
        {
            return _ProjectContext.TB_TipoServico.OrderBy(x => x.Nome).ToList();
        }
        public List<SubTipoServico> ListarSubTipoServicos()
        {
            return _ProjectContext.TB_SubTipoServico.Where(x => ListarTipoServicos().Any(y => y.Id == x.TipoServicoId)).OrderBy(x => x.Nome).ToList();
        }
        public List<SubTipoServico> ListarSubTipoServicosPorTipo(int objId)
        {
            return _ProjectContext.TB_SubTipoServico.Where(x => x.TipoServicoId == objId).ToList();
        }
        public List<Necessidade> ListarNecessidade()
        {
            return _ProjectContext.TB_Necessidade.ToList();
        }
        public List<Orcamentos> ListarOrcamentos()
        {
            return _ProjectContext.TB_Orcamentos.ToList();
        }
        public void ImprimirOrcamento(Orcamentos orcamentos)
        {

        }
        public void SolicitarOrcamento(Orcamentos orcamentos)
        {

        }
        public Orcamentos VisualizarOrcamento(Orcamentos orcamentos)
        {
            Orcamentos obj = _ProjectContext.TB_Orcamentos.Where(x => orcamentos.Id == x.Id).FirstOrDefault();
            return obj;
        }
        
    }
}
