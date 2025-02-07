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
    public class SupplierController : MainController
    {
        private readonly ISupplierService _service;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _service.GetAllAsync();
            var viewModels = _mapper.Map<List<SupplierViewModel>>(suppliers);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var supplier = await _service.GetByIdAsync(id);
            if (supplier == null) return NotFound();

            var viewModel = _mapper.Map<SupplierViewModel>(supplier);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SupplierViewModel viewModel)
        {
            var supplier = _mapper.Map<Supplier>(viewModel);
            await _service.AddAsync(supplier);
            var createdSupplier = _mapper.Map<SupplierViewModel>(supplier);
            return CustomResponse(createdSupplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SupplierViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var supplier = _mapper.Map<Supplier>(viewModel);
            await _service.UpdateAsync(supplier);
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
