using FluentValidation;
using FluentValidation.Results;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Config.Pipelines;

public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    private readonly IDomainNotification _domainNotification;
    private readonly IEnumerable<IValidator> _validators;

    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators,
        IDomainNotification domainNotification)
    {
        _validators = validators;
        _domainNotification = domainNotification;
    }

    private Task<TResponse> Notify(IEnumerable<ValidationFailure> failures)
    {
        var result = default(TResponse);

        foreach (var failure in failures)
            _domainNotification.Handle(failure.ErrorCode, failure.ErrorMessage);
        return Task.FromResult(result)!;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v =>
                v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Count > 0)
            .SelectMany(r => r.Errors)
            .ToList();

        return failures.Count != 0 ? await Notify(failures) : await next();
    }
}