using System.Threading;
using System.Threading.Tasks;
using CORS.Sample.Data;
using CORS.Sample.Data.Entities;
using CQRS.Sample.CQRS.RequestModels.CommandRequestModels;
using MediatR;

namespace CQRS.Sample.CQRS.Handlers.CommandHandlers {
  public class SaveProductCommandHandler : IRequestHandler<SaveProductRequestModel, int> {
    private readonly MyDbContext _dbContext;
    public SaveProductCommandHandler (MyDbContext dbContext) {
      this._dbContext = dbContext;
    }
    public async Task<int> Handle (SaveProductRequestModel request, CancellationToken cancellationToken ) {
      var newProduct = new Product {
        Name = request.Name,
        Manufacteur = request.Manufacteur,
        Description = request.Description,
        Price = request.Price
      };
      await _dbContext.Products.AddAsync (newProduct);
      await _dbContext.SaveChangesAsync ();
      return newProduct.ProductId;
    }
  }
}