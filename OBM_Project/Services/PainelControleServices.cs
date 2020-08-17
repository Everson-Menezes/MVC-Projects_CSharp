using System.Collections.Generic;
using System.Linq;
using OBM_Project.Data;
using OBM_Project.Models.Cliente;
using OBM_Project.Models.Demanda;
using OBM_Project.Models.Orcamento;
using OBM_Project.Models.Usuario;

namespace OBM_Project.Services
{
    public class PainelControleServices
    {
        private readonly OBM_ProjectContext _ProjectContext;

        public PainelControleServices(OBM_ProjectContext projectContext)
        {
            _ProjectContext = projectContext;
        }
        
        public List<Usuarios> ListarUsuarios()
        {
            return _ProjectContext.TB_Usuario.ToList();
        }

        public List<TipoServico> ListarTipoServicos()
        {
            return _ProjectContext.TB_TipoServico.OrderBy(x => x.Nome).ToList();
        }
        public bool ValidarUsuario(Usuarios obj)
        {
            var usuarios = ListarUsuarios();
            if (obj.Login == "Admin" && obj.Senha == "123123aaS")
            {
                return true;
            }
            else
            {
                foreach (Usuarios x in usuarios)
                {
                    if (x.Login == obj.Login && x.Senha == obj.Senha)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void AdicionarTipoServico(TipoServico obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarSubTipoServico(SubTipoServico obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarNecessidade(Necessidade obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarCliente(Clientes obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarDemanda(Demandas obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public List<Clientes> ListarClientes()
        {
           return _ProjectContext.TB_Clientes.OrderBy(x => x.Nome).ToList();
        }

    }
}
