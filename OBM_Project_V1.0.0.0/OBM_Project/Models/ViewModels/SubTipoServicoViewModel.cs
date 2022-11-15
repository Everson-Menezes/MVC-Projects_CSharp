using OBM_Project.Models.Orcamento;
using System.Collections.Generic;

namespace OBM_Project.Models.ViewModels
{
    public class SubTipoServicoViewModel
    {
        public SubTipoServico SubTipoServico { get; set; }
        public ICollection<TipoServico> TipoServicos { get; set; }

    }
}
