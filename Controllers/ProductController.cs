using System.Threading.Tasks;
using CQRS.Sample.CQRS.Contracts.CommandHandles;
using CQRS.Sample.CQRS.Contracts.QueryHandlers;
using CQRS.Sample.CQRS.RequestModels.CommandRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Sample.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ProductController : ControllerBase {
        private readonly ISaveProductCommandHandler saveProductCommandHandler;
        private readonly IAllProductsQueryHandler allProductsQueryHandler;
        private readonly IPriceRangeProductsQueryHandler priceRangeProductsQueryHandler;

        public ProductController (
            ISaveProductCommandHandler saveProductCommandHandler,
            IAllProductsQueryHandler allProductsQueryHandler,
            IPriceRangeProductsQueryHandler priceRangeProductsQueryHandler
        ) {
            this.saveProductCommandHandler = saveProductCommandHandler;
            this.allProductsQueryHandler = allProductsQueryHandler;
            this.priceRangeProductsQueryHandler = priceRangeProductsQueryHandler;
        }

        [HttpPost]
        [Route ("create")]
        public async Task<IActionResult> Create (SaveProductRequestModel requestModel) {
            var result = await saveProductCommandHandler.SaveAsync (requestModel);
            return Ok (result);
        }

        [HttpGet]
        [Route ("all")]
        public async Task<IActionResult> AllProducts () {
            var result = await allProductsQueryHandler.GetListAsync ();
            return Ok (result);
        }

        [HttpGet]
        [Route ("price-range")]
        public async Task<IActionResult> PriceRangeProducts (int minPrice, int maxPrice) {
            var result = await priceRangeProductsQueryHandler.PriceRangeProductsAsync (minPrice, maxPrice);
            return Ok (result);
        }
    }
}