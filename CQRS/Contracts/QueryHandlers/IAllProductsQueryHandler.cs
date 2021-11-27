using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.Sample.CQRS.ResponseModels.QueryResponseModels;

namespace CQRS.Sample.CQRS.Contracts.QueryHandlers
{
  public interface IAllProductsQueryHandler{
    Task<List<AllProductsResponseModel>> GetListAsync();
  }
    
}