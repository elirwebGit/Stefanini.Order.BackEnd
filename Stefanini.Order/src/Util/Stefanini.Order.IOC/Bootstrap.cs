using Microsoft.Extensions.DependencyInjection;
using Stefanini.Order.Application.App;
using Stefanini.Order.Domain.Interfaces;
using Stefanini.Order.Infra.Common;
using Stefanini.Order.Infra.UnitOfWork;

namespace Stefanini.Order.IOC
{
    public class Bootstrap
    {
        public static void Register(IServiceCollection service) {
            service.AddScoped<Application.Interfaces.IOrderApp, OrderApp>();

            service.AddScoped<Domain.Interfaces.IOrderRepository,Infra.Repository.OrderRepository>();
            service.AddScoped<Domain.Interfaces.IOrderItemRepository, Infra.Repository.OrderItemRepository>();
            service.AddScoped<Domain.Interfaces.IProductRepository, Infra.Repository.ProductRepository>();

            service.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            service.AddScoped<Infra.Context.EfCore>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();



        }
    }
            
}