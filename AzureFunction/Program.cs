using AzureFunction.Middleware;
using AzureFunction.Model;
using AzureFunction.Validation;
using FluentValidation;

using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(worker =>
    {
        worker.UseMiddleware<ValidateUserMiddleware<User, UserValidator>>();
    })
    .ConfigureServices(services =>
    {
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
    })
    .Build();

host.Run();
