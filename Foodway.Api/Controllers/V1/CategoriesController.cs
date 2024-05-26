using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Auth;
using Foodway.Domain.Requests.Category;
using Foodway.Shared.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(IDomainNotification domainNotification, ICategoryService categoryService) : base(domainNotification)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            return CreateResponse(await _categoryService.CreateAsync(request));
        }
    }
}
