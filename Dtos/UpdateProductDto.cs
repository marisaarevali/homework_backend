namespace ProductsApi.Dtos
{
    public class UpdateProductDto
    {        
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}