using AutoMapper;
using FlyPack.Application.Interfaces;
using FlyPack.Domain.Entities;
using FlyPack.Presentation.ViewModels;
using FlyTrackManager.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace FlyPack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _service.ObterTodosAsync();
            var viewModels = _mapper.Map<List<ProdutoViewModel>>(produtos);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produto = await _service.ObterPorIdAsync(id);
            if (produto == null) return NotFound();

            var viewModel = _mapper.Map<ProdutoViewModel>(produto);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoViewModel viewModel)
        {
            var produto = _mapper.Map<Produto>(viewModel);
            await _service.AdicionarAsync(produto);
            var produtoCriado = _mapper.Map<ProdutoViewModel>(produto);
            return CustomResponse(produtoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProdutoViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var produto = _mapper.Map<Produto>(viewModel);
            await _service.AtualizarAsync(produto);
            return CustomResponse(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
