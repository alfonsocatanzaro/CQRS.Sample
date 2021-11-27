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

        public ProductController (
            ISaveProductCommandHandler saveProductCommandHandler,
            IAllProductsQueryHandler allProductsQueryHandler
        ) {
            this.saveProductCommandHandler = saveProductCommandHandler;
            this.allProductsQueryHandler = allProductsQueryHandler;
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

    }
}