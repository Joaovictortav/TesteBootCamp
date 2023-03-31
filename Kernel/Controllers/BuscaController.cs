using Kernel.Api;
using Kernel.DTO;
using Kernel.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<string> Get()
    {
        // ApiBase mercadoLivre = ApiBase.Instance("mercado-livre");
        ApiBase amazon = ApiBase.Instance("amazon");
        
        // var ret = await mercadoLivre.SearchProduct();
        var resp = await amazon.SearchProduct();
        
        return await Task.FromResult("");
    }

    public async Task<string> GetProduct(string id, string store)
    {
        ApiBase mercadoLivre = ApiBase.Instance(store);
        return await mercadoLivre.GetProduct(id);
    }
}