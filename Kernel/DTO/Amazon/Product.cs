namespace Kernel.DTO.Amazon;

public class Product
{
    public string asin { get; set; }
    public string title { get; set; }
    public string code { get; set; }
    public string url { get; set; }
    public Price price { get; set; }
    public string totalProducts { get; set; }
    public string thumbnail { get; set; }
}