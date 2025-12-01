using MovimentacaoEstoque.Domain.Enums;

namespace MovimentacaoEstoque.Domain.Entities;

    public class Estoque
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int QtdEstoque { get; set; }

        public void AplicarMovimentacao(TipoBaseMovimentacao tipo, int quantidade)
        {
            if (tipo == TipoBaseMovimentacao.Entrada)
            {
                QtdEstoque += quantidade;
            }
            else if (tipo == TipoBaseMovimentacao.Saida)
            {
                if (QtdEstoque < quantidade)
                {
                    throw new InvalidOperationException("Erro: Estoque insuficiente para a movimentação de saída.");
                }
                QtdEstoque -= quantidade;
            }
        }
    }
