using System.Collections.Generic;
using CQRS.Sample.CQRS.ResponseModels.QueryResponseModels;
using MediatR;

namespace CQRS.Sample.CQRS.RequestModels.QueryRequestModels {
  public class AllProductsRequestModel : IRequest<List<AllProductsResponseModel>> {

  }
}