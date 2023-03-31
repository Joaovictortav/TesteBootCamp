using Kernel.DTO;
using Kernel.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kernel.Api;

public class MercadoLivre : ApiBase
{
    private readonly Dictionary<string, string> header = new Dictionary<string, string>()
    {
        { "Authorization", "Bearer 0UgEpizqJM7CSl3O9nbIzrTvTuaU2JZG" },
    };
    public MercadoLivre() : base("https://api.mercadolibre.com/")
    {
    }

    public override async Task<List<ProductResponse>> SearchProduct()
    {
        var t = new RestClient(baseUrl, "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("q", "playstation");
        param.TryAdd("status", "active");

        var result = await t.Run("sites/MLB/search", param);
        var ret = JsonConvert.DeserializeObject<List<Product>>(JObject.Parse(result).GetValue("result").ToString());
        return ConvertObject(ret);
    }

    private List<ProductResponse> ConvertObject(List<Product> ret)
    {
        throw new NotImplementedException();
    }

    public override async Task<string> GetProduct(string id)
    {
        var t = new RestClient(baseUrl, "GET");
        var result = await t.Run($"/products/{id}", headers: header);
        return result;
    }
}