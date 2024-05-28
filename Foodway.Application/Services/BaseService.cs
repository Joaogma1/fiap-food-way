using FluentValidation.Results;
using Foodway.Shared.Notifications;
using Microsoft.AspNetCore.Identity;

namespace Foodway.Application.Services;

public class BaseService
{
    protected IDomainNotification Notifications;

    public BaseService(IDomainNotification notifications)
    {
        Notifications = notifications;
    }

    protected void HandleValidationErrors(ValidationResult result)
    {
        var failures = result.Errors.Where(f => f != null).ToList();
        if (failures.Count != 0)
            failures.ForEach(f => Notifications.Handle(f.ErrorCode, f.ErrorMessage));
    }

    protected void HandleIdentityErrors(IEnumerable<IdentityError> errors)
    {
        foreach (var error in errors) Notifications.Handle(error.Code, error.Description);
    }
}