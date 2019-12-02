using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Trelleborg.Feature.CustomContainers.Controllers;
using Trelleborg.Feature.CustomContainers.Repositories;

namespace Trelleborg.Feature.CustomContainers.Pipelines
{
    internal class RegisterServices : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
          
            serviceCollection.AddTransient<IApiCisionRepository, ApiCisionRepository>();
            serviceCollection.AddTransient<ApiCisionController>();
        }
    }
}