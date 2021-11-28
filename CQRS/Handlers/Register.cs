using CQRS.Sample.CQRS.Contracts.CommandHandles;
using CQRS.Sample.CQRS.Contracts.QueryHandlers;
using CQRS.Sample.CQRS.Handlers.CommandHandlers;
using CQRS.Sample.CQRS.Handlers.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Sample.CQRS.Handlers {
  public class Register {
    public static void Handlers (IServiceCollection services) {
      services.AddScoped<ISaveProductCommandHandler, SaveProductCommandHandler> ();
      services.AddScoped<IAllProductsQueryHandler, AllProductsQueryHandler> ();
      services.AddScoped<IPriceRangeProductsQueryHandler, PriceRangeProductsQueryHandler> ();
    }
  }
}