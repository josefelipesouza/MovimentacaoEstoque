using Microsoft.AspNetCore.Mvc;
using MovimentacaoEstoque.Application.Handlers.Movimentacoes.Cadastrar;
using MovimentacaoEstoque.Application.Handlers.Movimentacoes.Listar;
using MovimentacaoEstoque.Application.Interfaces.Repositories;

namespace MovimentacaoEstoque.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMovimentacaoRepository _repository;
        private readonly CadastrarMovimentacaoHandler _cadastrarHandler;
        private readonly ListarMovimentacaoHandler _listarHandler;

        public MovimentacaoController(
            IMovimentacaoRepository repository,
            CadastrarMovimentacaoHandler cadastrarHandler,
            ListarMovimentacaoHandler listarHandler)
        {
            _repository = repository;
            _cadastrarHandler = cadastrarHandler;
            _listarHandler = listarHandler;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarMovimentacao([FromBody] CadastrarMovimentacaoRequest request)
        {
            var response = await _cadastrarHandler.Handle(request);

            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarMovimentacoes()
        {
            var request = new ListarMovimentacaoRequest();
            var response = await _listarHandler.Handle(request);

            if (!response.Sucesso)
                return StatusCode(500, response.Erros);

            return Ok(response.Movimentacoes);
        }
    }

