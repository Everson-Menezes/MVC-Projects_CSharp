using System.ComponentModel.DataAnnotations;

namespace OBM_Project.Models.Orcamento
{
    public class Necessidade
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public Necessidade()
        {

        }

        public Necessidade(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
