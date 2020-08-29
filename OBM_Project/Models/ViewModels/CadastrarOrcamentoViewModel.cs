using OBM_Project.Models.Orcamento;
using System.Collections.Generic;

namespace OBM_Project.Models.ViewModels
{
    public class CadastrarOrcamentoViewModel
    {
        public ICollection<TipoServico> TipoServicos { get; set; }
        public ICollection<SubTipoServico> SubTipoServicos { get; set; }
        public ICollection<Necessidade> Necessidades { get; set; }
        public Orcamentos Orcamentos { get; set; }
        //chama função javascript
        public string JavascriptToRun { get; set; }
        public int NumeracaoOrcamento { get; set; }
    }
}
