using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CORS.Sample.Data;
using CQRS.Sample.CQRS.RequestModels.QueryRequestModels;
using CQRS.Sample.CQRS.ResponseModels.QueryResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Sample.CQRS.Handlers.QueryHandlers {
  public class PriceRangeProductsQueryHandler : IRequestHandler<PriceRangeProductsRequestModel, List<PriceRangeProductsResponseModel>> {
    private readonly MyDbContext dbContext;

    public PriceRangeProductsQueryHandler (MyDbContext dbContext) {
      this.dbContext = dbContext;
    }

    public async Task<List<PriceRangeProductsResponseModel>> Handle (PriceRangeProductsRequestModel request, CancellationToken cancellationToken) {
      return await dbContext.Products
        .Where (_ => request.MinPrice <= _.Price && _.Price <= request.MaxPrice)
        .Select (_ => new PriceRangeProductsResponseModel {
          ProductId = _.ProductId,
            Name = _.Name,
            Price = _.Price
        })
        .ToListAsync ();
    }

  }
}