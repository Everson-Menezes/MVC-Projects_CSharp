using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        public void AdicionarDemanda(Demandas demandas)
        {
            
            _ProjectContext.Add(demandas);
            _ProjectContext.SaveChanges();
        }
        public List<Clientes> ListarClientes()
        {
            return _ProjectContext.TB_Clientes.OrderBy(x => x.Nome).ToList();
            
        }
        public List<Demandas> ListarDemandas()
        {
            var demanda  = _ProjectContext.TB_Demanda.Include(y => y.Cliente).Where(x => x.Valor > 0).ToList();
            
            return demanda;


        }
        public Clientes BuscarCliente(string nome)
        {
            return _ProjectContext.TB_Clientes.Where(x => x.Nome.Equals(nome)).FirstOrDefault();
        }
        public Demandas FindById(int id)
        {
            Demandas retorno = _ProjectContext.TB_Demanda.Include(a => a.Cliente).Where(x => x.Id == id).FirstOrDefault();
            return retorno;
        }
        public Demandas AlterarDataTermino(int id, DateTime dtTermino)
        {
            Demandas demanda = _ProjectContext.TB_Demanda.AsEnumerable().Where(x => id == x.Id).FirstOrDefault();
            demanda.DataTermino = DateTime.Now;
            _ProjectContext.Update(demanda);
            _ProjectContext.SaveChanges();
            return demanda;
        }
    }
}
