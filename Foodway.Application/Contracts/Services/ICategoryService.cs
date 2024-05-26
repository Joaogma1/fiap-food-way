using Foodway.Domain.Requests.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodway.Application.Contracts.Services
{
    public interface ICategoryService
    {
        Task<string> CreateAsync(CreateCategoryRequest req);
    }
}
