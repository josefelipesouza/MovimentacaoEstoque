using MovimentacaoEstoque.Application.Interfaces.Repositories;
using MovimentacaoEstoque.Domain.Entities;
using MovimentacaoEstoque.Domain.Enums;

namespace MovimentacaoEstoque.Application.Handlers.Movimentacoes.Cadastrar;

    public class CadastrarMovimentacaoHandler
    {
        private readonly IMovimentacaoRepository _repository;

        public CadastrarMovimentacaoHandler(IMovimentacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<CadastrarMovimentacaoResponse> Handle(CadastrarMovimentacaoRequest request)
        {
            
            var estoques = await _repository.ObterTodosEstoquesAsync();

            
            var estoque = estoques.FirstOrDefault(e => e.CodigoProduto == request.CodigoProduto);
            if (estoque == null)
            {
                return new CadastrarMovimentacaoResponse
                {
                    Sucesso = false,
                    Mensagem = $"Produto com código {request.CodigoProduto} não encontrado."
                };
            }

            try
            {
                
                estoque.AplicarMovimentacao((TipoBaseMovimentacao)request.TipoMovimentacao, request.Quantidade);

                
                await _repository.AtualizarEstoqueAsync(estoque);

                
                var movimentacao = new MovimentacaoEstoque.Domain.Entities.Movimentacao
                {
                    IdentificadorGuid = Guid.NewGuid().ToString(),
                    CodigoProduto = request.CodigoProduto,
                    Quantidade = request.Quantidade,
                    TipoMovimentacao = (int)request.TipoMovimentacao,
                    Descricao = request.Descricao,
                    DataMovimentacao = DateTime.Now
                };


                await _repository.CadastrarMovimentacaoAsync(movimentacao);

                return new CadastrarMovimentacaoResponse
                {
                    Sucesso = true,
                    Mensagem = $"Movimentação realizada com sucesso! Novo estoque: {estoque.QtdEstoque}.",
                    EstoqueFinal = estoque.QtdEstoque,
                    CodigoProduto = request.CodigoProduto
                };

            }
            catch (InvalidOperationException ex)
            {
                return new CadastrarMovimentacaoResponse
                {
                    Sucesso = false,
                    Mensagem = ex.Message
                };
            }
        }
    }
