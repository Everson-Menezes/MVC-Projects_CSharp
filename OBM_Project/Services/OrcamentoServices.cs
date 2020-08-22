using Microsoft.EntityFrameworkCore;
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

        public void AdicionarOrcamento(Orcamentos orcamentos)
        {
            _ProjectContext.Add(orcamentos);
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
        public List<Orcamentos> ListarOrcamentosPendentes()
        {
            return _ProjectContext.TB_Orcamentos.Include(x => x.Necessidade).Include(y => y.TipoServico).Include(w => w.SubTipoServico).Where(z => z.Valor == 0).ToList();
        }
        public List<Orcamentos> ListarOrcamentos()
        {
            return _ProjectContext.TB_Orcamentos.Where(x => x.Valor > 0).ToList();
        }

        public Orcamentos SolicitarOrcamento()
        {
            var retorno = _ProjectContext.TB_Orcamentos.Last();
            return retorno;
        }

        public Orcamentos VisualizarOrcamento(Orcamentos orcamentos)
        {
            var resultado = ListarOrcamentos().Where(x => orcamentos.Id == x.Id).FirstOrDefault();
            TipoServico tipoServico = _ProjectContext.TB_TipoServico.Where(x => resultado.TipoServicoId == x.Id).FirstOrDefault();
            SubTipoServico subTipo = _ProjectContext.TB_SubTipoServico.Where(x => resultado.SubTipoServicoId == x.Id).FirstOrDefault();
            resultado.SubTipoServico.Nome = subTipo.Nome;
            resultado.TipoServico.Nome = tipoServico.Nome;
            
            return resultado;
        }
        public Orcamentos FindById(int id)
        {
            Orcamentos retorno = _ProjectContext.TB_Orcamentos.AsEnumerable().Where(x => id == x.Id).FirstOrDefault();
            TipoServico tipoServico = _ProjectContext.TB_TipoServico.Where(x => retorno.TipoServicoId == x.Id).FirstOrDefault();
            SubTipoServico subTipo = _ProjectContext.TB_SubTipoServico.Where(x => retorno.SubTipoServicoId == x.Id).FirstOrDefault();
            Necessidade necessidade = _ProjectContext.TB_Necessidade.Where(x => retorno.NecessidadeId == x.Id).FirstOrDefault();
            retorno.SubTipoServico.Nome = subTipo.Nome;
            retorno.TipoServico.Nome = tipoServico.Nome;
            retorno.Necessidade.Nome = necessidade.Nome;
            return retorno;
        }
        public Orcamentos AlterarValor(int id, double valor)
        {
            Orcamentos orcamentos = _ProjectContext.TB_Orcamentos.AsEnumerable().Where(x => id == x.Id).FirstOrDefault();
            orcamentos.Valor = valor;
            _ProjectContext.Update(orcamentos);
            _ProjectContext.SaveChanges();
            return orcamentos;
        }
        
    }
}
