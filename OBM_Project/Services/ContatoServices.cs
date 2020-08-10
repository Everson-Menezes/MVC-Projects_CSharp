using OBM_Project.Data;
using OBM_Project.Models.Contato;
using System.Collections.Generic;
using System.Linq;

namespace OBM_Project.Services
{
    public class ContatoServices
    {
        private readonly OBM_ProjectContext _ProjectContext;

        public ContatoServices(OBM_ProjectContext projectContext)
        {
            _ProjectContext = projectContext;
        }
        public List<Area> ListarAreas()
        {
            return _ProjectContext.TB_Area.OrderBy(x => x.Nome).ToList();
        }
        public void AdicionarArea(Area obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
        public void AdicionarContato(Contatos obj)
        {
            _ProjectContext.Add(obj);
            _ProjectContext.SaveChanges();
        }
    }
}
