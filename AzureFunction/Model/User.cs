using FluentValidation;

using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;


namespace AzureFunction.Model;

public class User
{
    public string Email { get; set; }
    public string Password { get; set; }
}
