using Kernel.Util;

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

    public async override Task<string> SearchProduct()
    {
        var t = new RestClient(baseUrl, "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("query", "xbox");
        param.TryAdd("country", "BR");

        var result = await t.Run("product-search", param, header);
        return result;
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
}