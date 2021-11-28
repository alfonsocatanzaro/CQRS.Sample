using System.Collections.Generic;
using CQRS.Sample.CQRS.ResponseModels.QueryResponseModels;
using MediatR;

namespace CQRS.Sample.CQRS.RequestModels.QueryRequestModels
{
    public class PriceRangeProductsRequestModel: IRequest<List<PriceRangeProductsResponseModel>>
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}