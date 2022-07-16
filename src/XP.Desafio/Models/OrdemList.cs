using System;
using System.Windows;
using System.Windows.Media;
using XP.Desafio.Services.Models;

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

        //Temporario ate implementar um ColorConverter
        public SolidColorBrush TextColor => 
            Reducao > 0
            ? (SolidColorBrush)Application.Current.Resources["SCBXPRed"]
            : Reducao < 0
                ? (SolidColorBrush)Application.Current.Resources["SCBXPYellow"]
                : (SolidColorBrush)Application.Current.Resources["SCBXPBlue"];

        public OrdemList(Ordem ordem)
        {
            Id = ordem.Id;
            DateTime = ordem.DateTime;
            AssessorName = ordem.AssessorName;
            Conta = ordem.Conta;
            Ativo = ordem.Ativo;
            Tipo = ordem.Tipo;
            Quantidade = ordem.Quantidade;
            QuantidadeAparente = ordem.QuantidadeAparente;
            QuantidadeDisponivel = ordem.QuantidadeDisponivel;
            QuantidadeCancel = ordem.QuantidadeCancel;
            QuantidadeExec = ordem.QuantidadeExec;
            Valor = ordem.Valor;
            ValorDisponivel = ordem.ValorDisponivel;
            Objetivo = ordem.Objetivo;
            ObjetivoDisponivel = ordem.ObjetivoDisponivel;
            Reducao = ordem.Reducao;
        }
    }
}
