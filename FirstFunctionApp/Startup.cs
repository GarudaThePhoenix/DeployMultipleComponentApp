using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(DeployMultipleComponentApp.FirstFunctionApp.WebJobsStartup))]

namespace DeployMultipleComponentApp.FirstFunctionApp
{
    /// <summary>
    /// Supports startup operations related to Web Jobs
    /// </summary>
    /// <inheritdoc />
    [ExcludeFromCodeCoverage]
    public class WebJobsStartup : IWebJobsStartup
    {
        /// <inheritdoc />
        public void Configure(IWebJobsBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
        }
    }
}
