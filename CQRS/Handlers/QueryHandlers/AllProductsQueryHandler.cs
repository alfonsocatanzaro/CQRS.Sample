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
  public class AllProductsQueryHandler : IRequestHandler<AllProductsRequestModel, List<AllProductsResponseModel>> {
    private readonly MyDbContext _dbContext;

    public AllProductsQueryHandler (MyDbContext dbContext) {
      this._dbContext = dbContext;
    }
    public async Task<List<AllProductsResponseModel>> Handle (AllProductsRequestModel request, CancellationToken cancellationToken) {
      return await _dbContext.Products
        .Select (_ => new AllProductsResponseModel {
          ProductId = _.ProductId,
            Name = _.Name,
            Manufacturer = _.Manufacteur,
            Description = _.Description,
            Price = _.Price
        })
        .ToListAsync ();
    }
  }
}