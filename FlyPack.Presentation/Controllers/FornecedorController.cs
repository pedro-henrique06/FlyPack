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
    public class FornecedorController : MainController
    {
        private readonly IFornecedorService _service;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var fornecedores = await _service.ObterTodosAsync();
            var viewModels = _mapper.Map<List<FornecedorViewModel>>(fornecedores);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var fornecedor = await _service.ObterPorIdAsync(id);
            if (fornecedor == null) return NotFound();

            var viewModel = _mapper.Map<FornecedorViewModel>(fornecedor);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] FornecedorViewModel viewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(viewModel);
            await _service.AdicionarAsync(fornecedor);
            var fornecedorCriado = _mapper.Map<FornecedorViewModel>(fornecedor);
            return CustomResponse(fornecedorCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] FornecedorViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var fornecedor = _mapper.Map<Fornecedor>(viewModel);
            await _service.AtualizarAsync(fornecedor);
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
