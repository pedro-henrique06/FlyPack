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
    public class CustomerController : MainController
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllAsync();
            var viewModels = _mapper.Map<List<CustomerViewModel>>(customers);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return CustomResponse(id);

            var viewModel = _mapper.Map<CustomerViewModel>(customer);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerViewModel viewModel)
        {
            var customer = _mapper.Map<Customer>(viewModel);
            await _service.AddAsync(customer);
            var createdCustomer = _mapper.Map<CustomerViewModel>(customer);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CustomerViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var customer = _mapper.Map<Customer>(viewModel);
            await _service.UpdateAsync(customer);
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
