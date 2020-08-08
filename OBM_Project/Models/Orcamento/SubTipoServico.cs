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

        public SubTipoServico(int id, string nome, TipoServico tipoServico)
        {
            Id = id;
            Nome = nome;
            TipoServico = tipoServico;
            
        }
    }
}
