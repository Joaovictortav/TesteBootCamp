using Kernel.Util;

namespace Kernel.Api;

public class MercadoLivre : ApiBase
{
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
        //https://developers.mercadolivre.com.br/pt_br/descricao-de-produtos
    }
}