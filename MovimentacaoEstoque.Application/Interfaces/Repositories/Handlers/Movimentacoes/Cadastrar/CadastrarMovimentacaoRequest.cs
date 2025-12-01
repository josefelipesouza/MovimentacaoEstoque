using MovimentacaoEstoque.Domain.Enums;

namespace MovimentacaoEstoque.Application.Handlers.Movimentacoes.Cadastrar;

    public class CadastrarMovimentacaoRequest
    {

        public int CodigoProduto { get; set; }
        public TipoBaseMovimentacao TipoMovimentacao { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
