namespace MovimentacaoEstoque.Application.Handlers.Movimentacoes.Cadastrar;

    public class CadastrarMovimentacaoResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public int EstoqueFinal { get; set; }
        public int CodigoProduto { get; set; }
    }
