using System.IO;
using System.Net;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DeployMultipleComponentApp.SecondFunctionApp
{
    [PublicAPI]
    public static class SecondFunction
    {
        [PublicAPI]
        [FunctionName("FirstFunction")]
        [SupportedRequestFormat("application/json")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [QueryStringParameter("name", "Name used for generating greeting")]
        public static IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                methods: "get",
                Route = "v1/user/greeting")] HttpRequest request,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = request.Query["name"];

            if (string.IsNullOrWhiteSpace(name))
                return new BadRequestResult();

            return new OkObjectResult($"Hello {name}");
        }
    }
}
