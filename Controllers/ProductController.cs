using System.Threading.Tasks;
using CQRS.Sample.CQRS.RequestModels.CommandRequestModels;
using CQRS.Sample.CQRS.RequestModels.QueryRequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Sample.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ProductController : ControllerBase {
        private readonly IMediator mediator;

        public ProductController (IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route ("create")]
        public async Task<IActionResult> Create (SaveProductRequestModel requestModel) {
            var result = await mediator.Send (requestModel);
            return Ok (result);
        }

        [HttpGet]
        [Route ("all")]
        public async Task<IActionResult> AllProducts () {
            var result = await mediator.Send (new AllProductsRequestModel ());
            return Ok (result);
        }

        [HttpGet]
        [Route ("price-range")]
        public async Task<IActionResult> PriceRangeProducts ([FromQuery] PriceRangeProductsRequestModel request) {
            var result = await mediator.Send (request);
            return Ok (result);
        }
    }
}