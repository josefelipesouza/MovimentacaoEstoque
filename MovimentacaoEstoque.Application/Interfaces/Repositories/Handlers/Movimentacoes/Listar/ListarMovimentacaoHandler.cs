using MovimentacaoEstoque.Application.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MovimentacaoEstoque.Application.Handlers.Movimentacoes.Listar;

    public class ListarMovimentacaoHandler
    {
        private readonly IMovimentacaoRepository _repository;

        public ListarMovimentacaoHandler(IMovimentacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListarMovimentacaoResponse> Handle(ListarMovimentacaoRequest request)
        {
            var response = new ListarMovimentacaoResponse();

            try
            {
                var movimentacoes = await _repository.ObterTodasMovimentacoesAsync();
                
                
                response.Movimentacoes = movimentacoes
                    .Select(m => new MovimentacaoDto(m))
                    .ToList();
            }
            catch (System.Exception ex)
            {
                response.Sucesso = false;
                response.Erros.Add($"Ocorreu um erro ao listar as movimentações: {ex.Message}");
                
            }

            return response;
        }
    }
