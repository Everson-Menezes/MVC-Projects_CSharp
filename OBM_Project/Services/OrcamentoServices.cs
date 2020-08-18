using OBM_Project.Data;
using OBM_Project.Models.Orcamento;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

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
            CalcularOrcamento(obj);
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }

        private void CalcularOrcamento(Orcamentos obj)
        {
            
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
            //fazer join orçamentos, necessidade, tipo serviço e subtipo
            
            Orcamentos retorno = _ProjectContext.TB_Orcamentos.AsEnumerable().Where(x => id == x.Id).FirstOrDefault();
            return retorno;
        }
        
    }
}
