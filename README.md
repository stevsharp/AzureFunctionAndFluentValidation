# Azure Functions with FluentValidation

This project showcases how to leverage FluentValidation within Azure Functions to validate incoming requests before processing them. It utilizes a generic middleware approach to streamline request validation for various types of objects, specifically designed for Azure Functions running in the isolated model.

This project demonstrates how to integrate FluentValidation with Azure Functions, specifically designed for Azure Functions running in the isolated model. It showcases how to validate incoming requests before processing them, utilizing a generic middleware approach. This middleware provides a streamlined way to perform request validation for various types of objects.

## Prerequisites

Before running the Azure Functions project, ensure you have the following prerequisites installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [FluentValidation](https://fluentvalidation.net/)

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/stevsharp/AzureFunction.git

