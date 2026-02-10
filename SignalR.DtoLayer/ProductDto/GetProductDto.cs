namespace SignalR.DtoLayer.ProductDto;

public class GetProductDto
{
     public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Descripton { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}
