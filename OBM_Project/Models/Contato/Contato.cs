using OBM_Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OBM_Project.Models.Contato
{
    public class Contato
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Area Area { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
    }
}
