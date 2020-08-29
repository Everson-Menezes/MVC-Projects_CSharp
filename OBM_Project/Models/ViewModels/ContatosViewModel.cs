using OBM_Project.Models.Contato;
using System.Collections.Generic;

namespace OBM_Project.Models.ViewModels
{
    public class ContatosViewModel
    {
        public ICollection<Area> Areas { get; set; }
        public Contatos Contatos { get; set; }
        public string JavascriptToRun { get;  set; }
        public string Alertas { get;  set; }
    }
}
