using MovimentacaoEstoque.Domain.Entities;
using System.Collections.Generic;

namespace MovimentacaoEstoque.Application.Handlers.Movimentacoes.Listar;

    public class MovimentacaoDto
    {
        public int Id { get; set; }
        public string IdentificadorGuid { get; set; } 
        public int TipoMovimentacao { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; }

        public MovimentacaoDto(Movimentacao m)
        {
            Id = m.Identificador;
            IdentificadorGuid = m.IdentificadorGuid;
            TipoMovimentacao = m.TipoMovimentacao;
            CodigoProduto = m.CodigoProduto;
            Quantidade = m.Quantidade;
            Descricao = m.Descricao ?? string.Empty;
            DataMovimentacao = m.DataMovimentacao;
        }
    }

    public class ListarMovimentacaoResponse
    {
        public bool Sucesso { get; set; } = true;
        public List<string> Erros { get; set; } = new List<string>();
        public List<MovimentacaoDto> Movimentacoes { get; set; } = new List<MovimentacaoDto>();
    }

