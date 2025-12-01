using Microsoft.EntityFrameworkCore;
using MovimentacaoEstoque.Domain.Entities;

namespace MovimentacaoEstoque.Infrastructure.Data
{
    public class EstoqueDbContext : DbContext
    {
        public EstoqueDbContext(DbContextOptions<EstoqueDbContext> options)
            : base(options)
        {
        }

        public DbSet<Estoque> Estoques { get; set; } = null!;
        public DbSet<Movimentacao> Movimentacoes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estoque>().HasKey(e => e.CodigoProduto);
            modelBuilder.Entity<Movimentacao>().HasKey(m => m.Identificador);

            base.OnModelCreating(modelBuilder);
        }
    }
}
