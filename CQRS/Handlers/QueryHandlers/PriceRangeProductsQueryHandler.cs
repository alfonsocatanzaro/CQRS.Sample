using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORS.Sample.Data;
using CQRS.Sample.CQRS.Contracts.QueryHandlers;
using CQRS.Sample.CQRS.ResponseModels.QueryResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Sample.CQRS.Handlers.QueryHandlers {
  public class PriceRangeProductsQueryHandler : IPriceRangeProductsQueryHandler {
    private readonly MyDbContext dbContext;

    public PriceRangeProductsQueryHandler (MyDbContext dbContext) {
      this.dbContext = dbContext;
    }

    public async Task<List<PriceRangeProductsResponseModel>> PriceRangeProductsAsync (int minPrice, int maxPrice) {
      return await dbContext.Products
        .Where (_ => minPrice <= _.Price && _.Price <= maxPrice)
        .Select (_ => new PriceRangeProductsResponseModel {
          ProductId = _.ProductId,
            Name = _.Name,
            Price = _.Price
        })
        .ToListAsync ();
    }
  }
}