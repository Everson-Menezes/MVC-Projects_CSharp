using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            return _ProjectContext.TB_SubTipoServico.Where(x => ListarTipoServicos().Any(y => y.Id == x.TipoServicoId)).OrderBy(x => x.Nome).ToList();
        }
        public SubTipoServico ListarSubTipoServicosPorTipo(int objId)
        {
            return _ProjectContext.TB_SubTipoServico.FirstOrDefault(x => x.TipoServicoId == objId);
        }
        public List<Necessidade> ListarNecessidade()
        {
            return _ProjectContext.TB_Necessidade.ToList();
        }
        public List<Orcamentos> ListarOrcamentos()
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
            _ProjectContext.SaveChanges();
        }
        public void AdicionarNecessidade(Necessidade obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarOrcamento(Orcamentos obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
    }
}
