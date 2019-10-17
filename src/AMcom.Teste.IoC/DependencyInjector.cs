using AMcom.Teste.DAL.Interface;
using AMcom.Teste.DAL.Repository;
using AMcom.Teste.Service.Interface;
using AMcom.Teste.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AMcom.Teste.IoC
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IUbsService, UbsService>();


            //Data
            services.AddScoped<IUbsRepository, UbsRepository>();
        }
    }
}