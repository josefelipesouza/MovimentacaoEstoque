using MovimentacaoEstoque.Domain.Entities;

namespace MovimentacaoEstoque.Application.Interfaces.Repositories;

    public interface IMovimentacaoRepository
    {
        Task<List<Estoque>> ObterTodosEstoquesAsync();
       
        Task AtualizarEstoqueAsync(Estoque estoque); 
        Task CadastrarMovimentacaoAsync(Movimentacao movimentacao);
        Task<List<Movimentacao>> ObterTodasMovimentacoesAsync();
    }
