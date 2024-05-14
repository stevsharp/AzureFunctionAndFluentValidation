using FluentValidation;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using System.Net;
using System.Web.Mvc;

namespace AzureFunction.Middleware
{

    public class ValidateUserMiddleware<TUser, TValidator> : IFunctionsWorkerMiddleware
    where TUser : class
    where TValidator : IValidator<TUser>
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidateUserMiddleware(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var requestData = await context.GetHttpRequestDataAsync();

            var body = await new StreamReader(requestData.Body).ReadToEndAsync();

            var user = JsonConvert.DeserializeObject<TUser>(body);
            
            var userValidator = _serviceProvider.GetService<TValidator>();

            var validationResult = await userValidator.ValidateAsync(user, context.CancellationToken);

            if (!validationResult.IsValid)
            {
                var req = await context.GetHttpRequestDataAsync();

                var res = req!.CreateResponse();
                res.StatusCode = HttpStatusCode.BadRequest;

                await res.WriteStringAsync(JsonConvert.SerializeObject(validationResult.Errors.Select(x => x.ErrorMessage)));

                context.GetInvocationResult().Value = res;

                return;
            }

            await next(context);
        }
    }
}