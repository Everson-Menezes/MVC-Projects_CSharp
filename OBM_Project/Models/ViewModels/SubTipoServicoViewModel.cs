using Microsoft.AspNetCore.Mvc.Rendering;
using OBM_Project.Models.Orcamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBM_Project.Models.ViewModels
{
    public class SubTipoServicoViewModel
    {
        public SubTipoServico SubTipoServico { get; set; }
        public ICollection<TipoServico> TipoServicos { get; set; }

    }
}
