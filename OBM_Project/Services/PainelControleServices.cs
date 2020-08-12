using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using OBM_Project.Data;
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
        public List<TipoServico> ListarTipoServicos()
        {
            return _ProjectContext.TB_TipoServico.OrderBy(x => x.Nome).ToList();
        }
        public List<SubTipoServico> ListarSubTipoServicos()
        {
            return _ProjectContext.TB_SubTipoServico.Where(x => ListarTipoServicos().Any(y => y.Id == x.TipoServicoId)).OrderBy(x => x.Nome).ToList();
        }
        public List<SubTipoServico> ListarSubTipoServicosPorTipo(int objId)
        {
            return _ProjectContext.TB_SubTipoServico.Where(x => x.TipoServicoId == objId).ToList();
        }
        public List<Necessidade> ListarNecessidade()
        {
            return _ProjectContext.TB_Necessidade.ToList();
        }
        public List<Orcamentos> ListarOrcamentos()
        {
            return _ProjectContext.TB_Orcamentos.ToList();
        }
        public List<Usuarios> ListarUsuarios()
        {
            return _ProjectContext.TB_Usuario.ToList();
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
        public void AdicionarOrcamento(Orcamentos obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
    }
}
