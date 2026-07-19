using ECOM.MVC.Infrastructure.Interfaces;
using ECOM.MVC.Infrastructure.Services;

namespace ECOM.MVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEcomApiClient(this IServiceCollection services, IConfiguration config)
        {
            var baseUrl = config["EcomApi:BaseUrl"];

            if (string.IsNullOrEmpty(baseUrl))
                throw new InvalidOperationException("EcomApi:BaseUrl configuration is missing.");

            services.AddEcomClient<IAuthApiClient, AuthApiClient>(baseUrl);

            return services;
        }


        private static void AddEcomClient<TInterface, TImpl>(this IServiceCollection services, string baseUrl)
            where TInterface : class
            where TImpl : class, TInterface
        {
            services.AddHttpClient<TInterface, TImpl>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
        }
    }
}
