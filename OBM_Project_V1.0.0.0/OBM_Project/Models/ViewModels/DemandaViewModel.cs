using OBM_Project.Models.Cliente;
using OBM_Project.Models.Demanda;
using OBM_Project.Models.Orcamento;
using System.Collections.Generic;

namespace OBM_Project.Models.ViewModels
{
    public class DemandaViewModel
    {
        public List<Clientes> Cliente { get; set; }
        public List<Orcamentos> Orcamento { get; set; }
        public Demandas Demanda { get; set; }

    }
}
