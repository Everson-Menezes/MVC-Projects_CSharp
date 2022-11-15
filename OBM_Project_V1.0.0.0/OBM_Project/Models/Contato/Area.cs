using System.ComponentModel.DataAnnotations;

namespace OBM_Project.Models.Contato
{
    public class Area
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
       
        public Area()
        {

        }

        public Area(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
