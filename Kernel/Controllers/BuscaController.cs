using Kernel.Util;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<string> Get()
    {
        var t = new RestClient("https://api.mercadolibre.com/", "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("q", "playstation");
        param.TryAdd("status", "active");
        
        var result = await t.Run("sites/MLB/search", param);
        return result;
    }
    public async Task<string> GetRap()
    {
        var t = new RestClient("https://api.mercadolibre.com/sites/MLB/search?q=playstation&status=active", "GET");
        var param = new Dictionary<string, object>();

        var result = await t.Run("", param);
        return result;
    }
}