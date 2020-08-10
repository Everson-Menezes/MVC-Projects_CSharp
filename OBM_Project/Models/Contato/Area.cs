namespace OBM_Project.Models.Contato
{
    public class Area
    {
        public int Id { get; set; }
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
