using System;
using System.Windows;
using System.Windows.Media;

namespace XP.Desafio.Models
{
    public class OrdemList
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
        public string AssessorName { get; set; } = "-";
        public int Conta { get; set; } = 3934072;
        public string Ativo { get; set; } = "TF473";
        public string Tipo { get; set; } = "C";
        public int? Quantidade { get; set; } = 1;
        public int? QuantidadeAparente { get; set; }
        public int? QuantidadeDisponivel { get; set; }
        public int? QuantidadeCancel { get; set; }
        public int? QuantidadeExec { get; set; }
        public double? Valor { get; set; }
        public double? ValorDisponivel { get; set; }
        public double? Objetivo { get; set; }
        public double? ObjetivoDisponivel { get; set; }
        public double? Reducao { get; set; }
        public SolidColorBrush TextColor => 
            Reducao > 0
            ? (SolidColorBrush)Application.Current.Resources["SCBXPRed"]
            : Reducao < 0
                ? (SolidColorBrush)Application.Current.Resources["SCBXPYellow"]
                : (SolidColorBrush)Application.Current.Resources["SCBXPBlue"];

        public OrdemList(double reducao)
        {
            Reducao = reducao;
        }

        public OrdemList(int id, DateTime dateTime, string assessorName, int conta, string ativo, string tipo, int? quantidade, int? quantidadeAparente, int? quantidadeDisponivel, int? quantidadeCancel, int? quantidadeExec, double? valor, double? valorDisponivel, double? objetivo, double? objetivoDisponivel, double? reducao)
        {
            Id = id;
            DateTime = dateTime;
            AssessorName = assessorName;
            Conta = conta;
            Ativo = ativo;
            Tipo = tipo;
            Quantidade = quantidade;
            QuantidadeAparente = quantidadeAparente;
            QuantidadeDisponivel = quantidadeDisponivel;
            QuantidadeCancel = quantidadeCancel;
            QuantidadeExec = quantidadeExec;
            Valor = valor;
            ValorDisponivel = valorDisponivel;
            Objetivo = objetivo;
            ObjetivoDisponivel = objetivoDisponivel;
            Reducao = reducao;
        }
    }
}
