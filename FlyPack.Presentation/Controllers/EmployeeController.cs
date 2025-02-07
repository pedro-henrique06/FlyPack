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
    public class EmployeeController : MainController
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllAsync();
            var viewModels = _mapper.Map<List<EmployeeViewModel>>(employees);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null) return NotFound();

            var viewModel = _mapper.Map<EmployeeViewModel>(employee);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeViewModel viewModel)
        {
            var employee = _mapper.Map<Employee>(viewModel);
            await _service.AddAsync(employee);
            var createdEmployee = _mapper.Map<EmployeeViewModel>(employee);
            return CustomResponse(createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var employee = _mapper.Map<Employee>(viewModel);
            await _service.UpdateAsync(employee);
            return CustomResponse(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _service.RemoveAsync(id);
            return NoContent();
        }
    }

}
