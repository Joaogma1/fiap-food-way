using FluentValidation;
using Foodway.Application.Contracts.Services;
using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.Projections;
using Foodway.Domain.Requests.Clients;
using Foodway.Domain.ViewModels.Clients;
using Foodway.Shared.Notifications;

namespace Foodway.Application.Services;

public class ClientsService : BaseService, IClientsService
{
    private readonly IClientsRepository _clientsRepository;

    public ClientsService(IDomainNotification notifications, IClientsRepository clientsRepository) : base(notifications)
    {
        _clientsRepository = clientsRepository;
    }

    public async Task<string> CreateAsync(CreateClientRequest req)
    {
        if (await _clientsRepository.AnyAsync(x => x.CPF == req.CPF))
        {
            Notifications.Handle("Client", $"{req.CPF} does already exists");
            return "";
        }

        var createdClient = await _clientsRepository.AddAsync(new Client
        {
            Name = req.Name,
            CPF = req.CPF,
            Email = req.Email,
            CreatedBy = "BackOffice",
            LastModifiedBy = "BackOffice"
        });
        await _clientsRepository.SaveChanges();
        return createdClient.Id.ToString();
    }

    public async Task<ClientsViewModel?> GetByCpfAsync(string cpf)
    {
        if (!await _clientsRepository.AnyAsync(x => x.CPF == cpf)) return null;
        return (await _clientsRepository.FindAsyncAsNoTracking(x => x.CPF == cpf)).ToViewModel();
    }
}