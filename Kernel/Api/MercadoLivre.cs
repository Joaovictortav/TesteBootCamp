using Kernel.Util;

namespace Kernel.Api;

public class MercadoLivre : ApiBase
{
    private readonly Dictionary<string, string> header = new Dictionary<string, string>()
    {
        { "Authorization", "Bearer 0UgEpizqJM7CSl3O9nbIzrTvTuaU2JZG" },
    };
    public MercadoLivre(string baseUrl) : base(baseUrl)
    {
    }

    public override async Task<string> SearchProduct()
    {
        var t = new RestClient(baseUrl, "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("q", "playstation");
        param.TryAdd("status", "active");

        var result = await t.Run("sites/MLB/search", param);
        return result;
    }

    public override async Task<string> GetProduct(string id)
    {
        var t = new RestClient(baseUrl, "GET");
        var result = await t.Run($"items/{id}/description", headers: header);
        return result;
    }
}