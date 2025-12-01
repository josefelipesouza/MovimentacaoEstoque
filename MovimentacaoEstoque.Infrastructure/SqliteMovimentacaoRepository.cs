using Microsoft.EntityFrameworkCore;
using MovimentacaoEstoque.Application.Interfaces.Repositories;
using MovimentacaoEstoque.Domain.Entities;
using MovimentacaoEstoque.Infrastructure.Data;

namespace MovimentacaoEstoque.Infrastructure;

    public class SqliteMovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly EstoqueDbContext _context;

        public SqliteMovimentacaoRepository(EstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estoque>> ObterTodosEstoquesAsync()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task AtualizarEstoqueAsync(Estoque estoque)
        {
            _context.Estoques.Update(estoque);
            await _context.SaveChangesAsync();
        }

        public async Task CadastrarMovimentacaoAsync(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Movimentacao>> ObterTodasMovimentacoesAsync()
        {
            
            return await _context.Movimentacoes
                                 
                                 .OrderByDescending(m => m.DataMovimentacao)
                                 .ToListAsync();
        }
    }

