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
    public class FuncionarioController : MainController
    {
        private readonly IFuncionarioService _service;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var funcionarios = await _service.ObterTodosAsync();
            var viewModels = _mapper.Map<List<FuncionarioViewModel>>(funcionarios);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var funcionario = await _service.ObterPorIdAsync(id);
            if (funcionario == null) return NotFound();

            var viewModel = _mapper.Map<FuncionarioViewModel>(funcionario);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] FuncionarioViewModel viewModel)
        {
            var funcionario = _mapper.Map<Funcionario>(viewModel);
            await _service.AdicionarAsync(funcionario);
            var funcionarioCriado = _mapper.Map<FuncionarioViewModel>(funcionario);
            return CustomResponse(funcionarioCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] FuncionarioViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var funcionario = _mapper.Map<Funcionario>(viewModel);
            await _service.AtualizarAsync(funcionario);
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
