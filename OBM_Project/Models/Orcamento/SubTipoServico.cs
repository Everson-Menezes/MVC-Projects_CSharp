namespace OBM_Project.Models.Orcamento
{
    public class SubTipoServico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoServico TipoServico { get;set;}
        public int TipoServicoId { get; set; }
        public SubTipoServico()
        {

        }

        public SubTipoServico(string nome, TipoServico tipoServico, int tipoServicoId)
        {
            Nome = nome;
            TipoServico = tipoServico;
            TipoServicoId = tipoServicoId;
        }
    }
}
