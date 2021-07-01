using Core.Models.Table;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Repositories.Ef
{
    public class BaseEfRepository
    {
        public BaseEfRepository(IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
        }

        protected IServiceScopeFactory ServiceScopeFactory { get; private set; }

        public ApiContext GetApiContext(IServiceScope serviceScope)
        {
            return serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
        }
    }
}
