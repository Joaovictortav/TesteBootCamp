using Kernel.Api;
using Kernel.Util;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<string> Get()
    {
        ApiBase mercadoLivre = ApiBase.Instance("mercado-livre");
        ApiBase amazon = ApiBase.Instance("amazon");
        // ApiBase charlinhos = ApiBase.Instance("charlinhos");
        
        var ret = await mercadoLivre.SearchProduct();
        var resp = await amazon.SearchProduct();
        // var ret2 = await charlinhos.SearchProduct();
        
        return await Task.FromResult("");
    }

    public async Task<string> GetProduct(string id, string store)
    {
        ApiBase mercadoLivre = ApiBase.Instance(store);
        return await mercadoLivre.GetProduct(id);
    }
}