using System.Threading.Tasks;
using CORS.Sample.Data;
using CORS.Sample.Data.Entities;
using CQRS.Sample.CQRS.Contracts.CommandHandles;
using CQRS.Sample.CQRS.RequestModels.CommandRequestModels;

namespace CQRS.Sample.CQRS.Handlers.CommandHandlers {
  public class SaveProductCommandHandler : ISaveProductCommandHandler {
    private readonly MyDbContext _dbContext;
    public SaveProductCommandHandler (MyDbContext dbContext) {
      this._dbContext = dbContext;
    }
    public async Task<int> SaveAsync (SaveProductRequestModel requestModel) {
      var newProduct = new Product {
        Name = requestModel.Name,
        Manufacteur = requestModel.Manufacteur,
        Description = requestModel.Description,
        Price = requestModel.Price
      };
      await _dbContext.Products.AddAsync (newProduct);
      await _dbContext.SaveChangesAsync ();
      return newProduct.ProductId;
    }
  }
}