using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORS.Sample.Data;
using CQRS.Sample.CQRS.Contracts.QueryHandlers;
using CQRS.Sample.CQRS.ResponseModels.QueryResponseModels;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Sample.CQRS.Handlers.QueryHandlers {
  public class AllProductsQueryHandler : IAllProductsQueryHandler {
    private readonly MyDbContext _dbContext;

    public AllProductsQueryHandler (MyDbContext dbContext) {
      this._dbContext = dbContext;
    }
    public async Task<List<AllProductsResponseModel>> GetListAsync () {
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