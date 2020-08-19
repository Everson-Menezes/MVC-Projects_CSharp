
using OBM_Project.Models.Cliente;
using OBM_Project.Models.Orcamento;
using System;
using System.ComponentModel.DataAnnotations;

namespace OBM_Project.Models.Demanda
{
    public class Demandas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int OrcamentoId { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public double Valor { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataTermino { get; set; }
        public Demandas()
        {

        }
        public Demandas(int id, int clienteId, int orcamentoId, double valor, DateTime dataAbertura)
        {
            Id = id;
            ClienteId = clienteId;
            OrcamentoId = orcamentoId;
            Valor = valor;
            DataAbertura = dataAbertura;
        }
    }
}
