using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceColleciton)
        {
            serviceColleciton.AddMemoryCache();
            serviceColleciton.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceColleciton.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
