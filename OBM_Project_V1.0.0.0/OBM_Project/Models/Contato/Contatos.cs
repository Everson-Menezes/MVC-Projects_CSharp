
using System.ComponentModel.DataAnnotations;

namespace OBM_Project.Models.Contato
{
    public class Contatos
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public Area Area { get; set; }
        public int AreaId { get; set; }
        [Required]
        public string Assunto { get; set; }
        [Required]
        public string Conteudo { get; set; }

        public Contatos()
        {

        }

        public Contatos(int id, string nome, string email, string telefone, Area area, string assunto, string conteudo, int areaId)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Area = area;
            AreaId = areaId;
            Assunto = assunto;
            Conteudo = conteudo;
        }
    }
}
