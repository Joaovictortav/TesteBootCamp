using Kernel.Util;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<string> Get()
    {
        var t = new RestClient("https://api.mercadolivre.com/sites/MLB/search?q=playstation&status=active", "GET");
        var param = new Dictionary<string, object>();
        
        
        var result = await t.Run("", param);
        return result;
    }
}