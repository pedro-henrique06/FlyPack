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
    public class ProductController : MainController
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper, INotificator notificator)
            : base(notificator)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            var viewModels = _mapper.Map<List<ProductViewModel>>(products);
            return CustomResponse(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null) return NotFound();

            var viewModel = _mapper.Map<ProductViewModel>(product);
            return CustomResponse(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewModel viewModel)
        {
            var product = _mapper.Map<Product>(viewModel);
            await _service.AddAsync(product);
            var createdProduct = _mapper.Map<ProductViewModel>(product);
            return CustomResponse(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var product = _mapper.Map<Product>(viewModel);
            await _service.UpdateAsync(product);
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
