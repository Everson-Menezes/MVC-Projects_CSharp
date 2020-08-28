using System;
using System.ComponentModel.DataAnnotations;

namespace OBM_Project.Models.Orcamento
{
    public class Orcamentos
    {
        public int Id { get; set; }
        [Required]
        public string Solicitante { get; set; }
        [Required]
        public string SolicitanteContato { get; set; }
        public TipoServico TipoServico { get; set; }
        public int TipoServicoId { get; set; }
        [Required]
        public SubTipoServico SubTipoServico { get; set; }
        public int SubTipoServicoId { get; set; }
        [Required]
        public Necessidade Necessidade { get; set; }
        public int NecessidadeId { get; set; }
        [Required]
        public string Observacao { get; set; }
        public DateTime DataGeracao { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double Valor { get; set; }
        public Orcamentos()
        {

        }

        public Orcamentos(int id, TipoServico tipoServico, SubTipoServico subTipoServico, Necessidade necessidade, string observacao, string solicitante)
        {
            Id = id;
            TipoServico = tipoServico;
            SubTipoServico = subTipoServico;
            Necessidade = necessidade;
            Observacao = observacao;
            Solicitante = solicitante;
            DataGeracao = DateTime.Now;
        }
        
    }
}
