using System.Threading.Tasks;
using CQRS.Sample.CQRS.Contracts.CommandHandles;
using CQRS.Sample.CQRS.RequestModels.CommandRequestModels;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Sample.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class ProductController : ControllerBase {
        private readonly ISaveProductCommandHandler saveProductCommandHandler;
        public ProductController (
            ISaveProductCommandHandler saveProductCommandHandler
        ) {
            this.saveProductCommandHandler = saveProductCommandHandler;
        }

        [HttpPost]
        [Route ("create")]
        public async Task<IActionResult> Create (SaveProductRequestModel requestModel) {
            var result = await saveProductCommandHandler.SaveAsync (requestModel);
            return Ok (result);
        }



    }
}