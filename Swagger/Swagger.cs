using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Attribute;
using JetBrains.Annotations;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace DeployMultipleComponentApp
{
    /// <summary>
    /// Provides Azure Function endpoints for Swagger Integration
    /// </summary>
    [ExcludeFromCodeCoverage]
    [PublicAPI]
    public static class SwaggerFunctions
    {
        /// <summary>
        /// Gets swagger documentation json for current application
        /// </summary>
        /// <param name="request">Instance of <see cref="HttpRequestMessage"/> received from Client</param>
        /// <param name="swashBuckleClient">Instance of <see cref="ISwashBuckleClient"/> configured using Web Jobs Startup</param>
        /// <returns>Instance of <see cref="HttpResponseMessage"/> with JSON document as body</returns>
        [SwaggerIgnore]
        [FunctionName("Swagger")]
        [PublicAPI]
        public static Task<HttpResponseMessage> Swagger(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                methods:"get",
                Route = "swagger/json")] HttpRequestMessage request,
            [SwashBuckleClient]ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerDocumentResponse(request));
        }

        /// <summary>
        /// Gets Swagger UI for current application
        /// </summary>
        /// <param name="request">Instance of <see cref="HttpRequestMessage"/> received from Client</param>
        /// <param name="swashBuckleClient">Instance of <see cref="ISwashBuckleClient"/> configured using Web Jobs Startup</param>
        /// <returns>Instance of <see cref="HttpResponseMessage"/> with HTML response</returns>
        [SwaggerIgnore]
        [FunctionName("SwaggerUi")]
        [PublicAPI]
        public static Task<HttpResponseMessage> SwaggerUi(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                methods: "get",
                Route = "swagger/ui")]
            HttpRequestMessage request,
            [SwashBuckleClient] ISwashBuckleClient swashBuckleClient)
        {
            return Task.FromResult(swashBuckleClient.CreateSwaggerUIResponse(request, "swagger/json"));
        }
    }
}
