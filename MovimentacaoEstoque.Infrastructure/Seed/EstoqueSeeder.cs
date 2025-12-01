using MovimentacaoEstoque.Domain.Entities;
using MovimentacaoEstoque.Infrastructure.Data;
using System.Linq; 

namespace MovimentacaoEstoque.Infrastructure.Seed;

    public static class EstoqueSeeder
    {
        public static void Seed(EstoqueDbContext context)
        {
            // Verifica se a tabela de Estoques está vazia antes de popular.
            if (!context.Estoques.Any())
            {
                var estoquesIniciais = new List<Estoque>
                {
                    // CORRIGIDO: Propriedade QtdEstoque (Quantidade em Estoque)
                    new Estoque { CodigoProduto = 101, DescricaoProduto = "Caneta Azul", QtdEstoque = 150 },
                    new Estoque { CodigoProduto = 102, DescricaoProduto = "Caderno Universitário", QtdEstoque = 75 },
                    new Estoque { CodigoProduto = 103, DescricaoProduto = "Borracha Branca", QtdEstoque = 200 },
                    new Estoque { CodigoProduto = 104, DescricaoProduto = "Lápis Preto HB", QtdEstoque = 320 },
                    new Estoque { CodigoProduto = 105, DescricaoProduto = "Marcador de Texto Amarelo", QtdEstoque = 90 }
                };

                context.Estoques.AddRange(estoquesIniciais);
                context.SaveChanges();
            }
        }
    }
