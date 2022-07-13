using System;

namespace XP.Desafio.Models
{
    public class Ordem
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string AssessorName { get; set; } = "-";
        public int Conta { get; set; }
        public string Ativo { get; set; } = "TF473";
        public string Tipo { get; set; } = "C";
        public int Quantidade { get; set; }
        public int QuantidadeAparente { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int QuantidadeExec { get; set; }
        public double Valor { get; set; }
        public double ValorDisponivel { get; set; }
        public double Objetivo { get; set; }
        public double ObjetivoDisponivel { get; set; }
        public double Reducao { get; set; }
    }
}
