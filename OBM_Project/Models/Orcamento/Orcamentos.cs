using System;

namespace OBM_Project.Models.Orcamento
{
    public class Orcamentos
    {
        public int Id { get; set; }
        public TipoServico TipoServico { get; set; }
        public int TipoServicoId { get; set; }
        public SubTipoServico SubTipoServico { get; set; }
        public int SubTipoServicoId { get; set; }
        public Necessidade Necessidade { get; set; }
        public int NecessidadeId { get; set; }
        public string Observacao { get; set; }
        public DateTime DataGeracao { get; set; }
        public double Valor { get; set; }
        public Orcamentos()
        {

        }

        public Orcamentos(int id, TipoServico tipoServico, SubTipoServico subTipoServico, Necessidade necessidade, string observacao)
        {
            Id = id;
            TipoServico = tipoServico;
            SubTipoServico = subTipoServico;
            Necessidade = necessidade;
            Observacao = observacao;
            DataGeracao = DateTime.Now;
        }
    }
}
