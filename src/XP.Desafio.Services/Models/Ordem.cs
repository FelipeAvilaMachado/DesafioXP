namespace XP.Desafio.Services.Models
{
    public record Ordem
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
    }
}
