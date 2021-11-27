using CQRS.Sample.CQRS.Contracts.CommandHandles;
using CQRS.Sample.CQRS.Handlers.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Sample.CQRS.Handlers {
  public class Register {
    public static void Handlers (IServiceCollection services) {
      services.AddScoped<ISaveProductCommandHandler, SaveProductCommandHandler> ();
    }
  }
}