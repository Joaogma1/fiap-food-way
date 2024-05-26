using System.Net;
using System.Text.Json;
using Foodway.Shared.Notifications;
using Foodway.Shared.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Foodway.Config.Handlers;

public static class ApplicationExceptionHandler
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(applicationError =>
        {
            applicationError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    var domainNotification =
                        context.RequestServices.GetService(typeof(IDomainNotification)) as IDomainNotification;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "Application/json";
                    EnvelopResult? result = null;

                    var notification = new Notification("InternalError", "An Internal Error Occured");

                    if (domainNotification == null) result = EnvelopResult.Fail(new[] { notification });
                    if (domainNotification?.HasNotifications() == false)
                    {
                        domainNotification.Handle(notification);
                        result = EnvelopResult.Fail(domainNotification.Notifications);
                    }

                    var response = JsonSerializer.Serialize(result);

                    await context.Response.WriteAsync(response);
                }
            });
        });
    }
}