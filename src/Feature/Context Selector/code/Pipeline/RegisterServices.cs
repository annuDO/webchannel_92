  using Microsoft.Extensions.DependencyInjection;
  using Sitecore.DependencyInjection;
using Trelleborg.Feature.ContextSelector.Controllers;
using Trelleborg.Feature.ContextSelector.Repositories;

namespace Trelleborg.Feature.ContextSelector.Pipeline
  {
    internal class RegisterServices : IServicesConfigurator
    {
      public void Configure(IServiceCollection serviceCollection)
      {
        serviceCollection.AddTransient<ILanguageSelectorRepository, LanguageSelectorRepository>();
        serviceCollection.AddTransient<LanguageController>();
      serviceCollection.AddTransient<IMarketSelectorRepository, MarketSelectorRepository>();
      serviceCollection.AddTransient<MarketSelectorController>();
      serviceCollection.AddTransient<ISiteSelectorRepository, SiteSelectorRepository>();
      serviceCollection.AddTransient<SiteController>();
    }
    }
  }


