namespace CQRS.Sample.CQRS.RequestModels.CommandRequestModels {
    public class SaveProductRequestModel {
        public string Name { get; set; }
        public string Manufacteur { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}