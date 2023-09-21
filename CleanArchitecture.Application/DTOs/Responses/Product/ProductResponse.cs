namespace CleanArchitecture.Application.DTOs.Responses.Product
{
    public class ProductResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
    }
}
