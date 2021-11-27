using System.Threading.Tasks;
using CQRS.Sample.CQRS.RequestModels.CommandRequestModels;

namespace CQRS.Sample.CQRS.Contracts.CommandHandles {
  public interface ISaveProductCommandHandler {
    Task<int> SaveAsync(SaveProductRequestModel requestModel);
  }
}