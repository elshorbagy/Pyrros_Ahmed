using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Repository.Models;
using Service.AccountService;
using SftpClient.Extension;

namespace Function
{
    public class AccountOperation
    {
        private readonly ILogger<AccountOperation> _logger;
        private readonly IAccountService _accountService;

        public AccountOperation(IAccountService accountService, ILogger<AccountOperation> log)
        {
            _logger = log;
            _accountService = accountService;
        }

        [FunctionName("Account")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "Account" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "accountId", In = ParameterLocation.Path, Required = true, Type = typeof(AccountDatum), Description = "Account Id")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(AccountDatum), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                string accountId;

                switch (req.Method)
                {
                    case "POST":
                        {
                            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                            requestBody.ValidateString();
                            var request = JsonConvert.DeserializeObject<AccountDatum>(requestBody);
                            _logger.LogInformation($"Adding acccount {request.Id} succeeded");
                            return new OkObjectResult(await _accountService.AddNewAccountAsync(request));
                        }

                    case "GET":
                        accountId = req.Query["id"];
                        accountId.ValidateString();
                        _logger.LogInformation($"Get Account by id {accountId} succeeded");
                        return new OkObjectResult(await _accountService.GetAccountByIdAsync(int.Parse(accountId)));
                    default:
                        return new NoContentResult();
                }
            }
            catch (Exception exception)
            {
                var errorMessage = exception.InnerException is not null ?
                    exception.InnerException.Message : exception.Message;

                _logger.LogError(errorMessage);

                return new BadRequestObjectResult(errorMessage);
            }
        }
    }
}