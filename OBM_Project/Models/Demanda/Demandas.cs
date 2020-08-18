
using OBM_Project.Models.Cliente;
using OBM_Project.Models.Orcamento;
using System;

namespace OBM_Project.Models.Demanda
{
    public class Demandas
    {
        public int Id { get; set; }
        public Clientes Cliente { get; set; }
        public int ? ClienteId { get; set; }
        public Orcamentos Orcamento { get; set; }
        public int OrcamentoId { get; set; }
        public double Valor { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataTermino { get; set; }
        public Demandas()
        {

        }

        public Demandas(int id, Clientes cliente, Orcamentos orcamento)
        {
            Id = id;
            Cliente = cliente;
            Orcamento = orcamento;
            DataAbertura = DateTime.Now;
        }
    }
}
