using FluentValidation;
using Foodway.Application.Contracts.Services;
using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.Projections;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Clients;
using Foodway.Domain.ViewModels.Clients;
using Foodway.Shared.Helpers;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;

namespace Foodway.Application.Services
{
    public class ClientsService : BaseService, IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IValidator<CreateClientRequest> _createClientValidator;

        public ClientsService(IDomainNotification notifications, IClientsRepository clientsRepository, IValidator<CreateProductRequest> createProductValidator) : base(notifications)
        {
            _clientsRepository = clientsRepository;
            _createClientValidator = createProductValidator;
        }

        public async Task<string> CreateAsync(CreateProductRequest req)
        {
            var reqValidation = await _createClientValidator.ValidateAsync(req);

            if (!reqValidation.IsValid)
            {
                HandleValidationErrors(reqValidation);
                return "";
            }

            if (await _categoryRepository.AnyAsync(x => x.CPF == req.CPF))
            {
                this.Notifications.Handle("Client", $"{req.CPF} does already exists");
                return "";
            }

            var createdClient = await _clientsRepository.AddAsync(new Clients
            { 
                Name = req.Name,
                CPF = req.CPF,
                Email = req.Email,
                CreatedBy = "BackOffice",
                LastModifiedBy = "BackOffice",

            });
            await _clientsRepository.SaveChanges();
            return createdClient.Id.ToString();
        }

        public async Task<ProductViewModel?> GetByCPFAsync(string cpf)
        {
            if (!(await _clientsRepository.AnyAsync(x => x.CPF == cpf)))
            {
                return null;
            }
            var joins = new IncludeHelper<Clients>().Include(x => x.Category).Includes;

            return (await _clientsRepository.FindAsyncAsNoTracking(x => x.CPF == cpf, joins)).ToViewModel();
        }
    }

   
}
