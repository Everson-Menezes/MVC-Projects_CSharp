namespace OBM_Project.Models.Orcamento
{
    public class Orcamento
    {
        public int Id { get; set; }
        public TipoServico TipoServico { get; set; }
        public SubTipoServico SubTipoServico { get; set; }
        public Necessidade Necesssidade { get; set; }
        public string Observacao { get; set; }
    }
}
