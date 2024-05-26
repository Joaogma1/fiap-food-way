using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Product;
using Foodway.Shared.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IDomainNotification domainNotification, IProductService productService) : base(domainNotification)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreatedResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CreatedResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest req )
        {
            return CreatedResponse(await _productService.CreateAsync(req));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid? id, [FromBody] UpdateProductRequest req)
        {
            req.Id = id;
            var result = await _productService.UpdateAsync(req);
            if (id == null)
            {
                return CreatedResponse(result);
            }

            return NoContentResponse();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CreatedResponse();
        }

    }
}
