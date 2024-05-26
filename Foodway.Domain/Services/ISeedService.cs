namespace Foodway.Domain.Services;

public interface ISeedService
{
    Task SeedRolesAsync();
    Task SeedUsersAsync();
}