
namespace OBM_Project.Models.Usuario
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Usuarios()
        {

        }
        public Usuarios(int id, string login, string senha, string nome, string email)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Nome = nome;
            Email = email;
        }
    }
}
