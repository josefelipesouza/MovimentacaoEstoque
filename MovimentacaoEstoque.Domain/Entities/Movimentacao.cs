namespace MovimentacaoEstoque.Domain.Entities;

    public class Movimentacao
    {
        public int Identificador { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public int TipoMovimentacao { get; set; }
        public string? Descricao { get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; }

    }

