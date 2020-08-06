namespace OBM_Project.Models.Orcamento
{
    public class TipoServico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoServico()
        {

        }

        public TipoServico(string nome)
        {
            Nome = nome;
        }
    }
}
