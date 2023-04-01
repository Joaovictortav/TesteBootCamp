using Kernel.DTO;
using Kernel.DTO.Amazon;
using Kernel.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kernel.Api;

public class Amazon : ApiBase
{
    private readonly Dictionary<string, string> header = new Dictionary<string, string>()
    {
        { "X-RapidAPI-Key", "e143188d47msh520d387e7756ceap1a336bjsn08c4b4ece15c" },
        { "X-RapidAPI-Host", "amazon23.p.rapidapi.com" }
    };
    static Amazon()
    {
    }

    public Amazon() : base("https://amazon23.p.rapidapi.com/")
    {
    }

    public override async Task<List<ProductResponse>> SearchProduct(string name)
    {
        var t = new RestClient(baseUrl, "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("query", "xbox");
        param.TryAdd("country", "BR");

        var result = await t.Run("product-search", param, header);
        var ret = JsonConvert.DeserializeObject<List<Product>>(JObject.Parse(result).GetValue("result").ToString());
        return ConvertObject(ret);

    }

    public async override Task<string> GetProduct(string id)
    {
        var t = new RestClient(baseUrl, "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("asin", id);
        param.TryAdd("country", "BR");

        var result = await t.Run("product-details", param, header);
        return result;
    }

    public List<ProductResponse> ConvertObject(List<Product> products)
    {
        var retorno = new List<ProductResponse>();
        foreach (var p in products)
        {
            retorno.Add(new ProductResponse()
            {
                price = p.price.current_price,
                stockQuantity = p.totalProducts,
                description = p.title,
                provider = ""
            });
        }

        return retorno;
    }
}