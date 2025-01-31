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
    public class ClienteController : MainController
    {
        private readonly IClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService service, IMapper mapper, INotificator notificator) 
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var clientes = await _service.ObterTodosAsync();
            var viewModels = _mapper.Map<List<ClienteViewModel>>(clientes);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var cliente = await _service.ObterPorIdAsync(id);
            if (cliente == null) return CustomResponse(id);

            var viewModel = _mapper.Map<ClienteViewModel>(cliente);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ClienteViewModel viewModel)
        {
            var cliente = _mapper.Map<Cliente>(viewModel);
            await _service.AdicionarAsync(cliente);
            var clienteCriado = _mapper.Map<ClienteViewModel>(cliente);
            return CreatedAtAction(nameof(ObterPorId), new { id = clienteCriado.Id }, clienteCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] ClienteViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var cliente = _mapper.Map<Cliente>(viewModel);
            await _service.AtualizarAsync(cliente);
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
