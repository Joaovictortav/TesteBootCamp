using Kernel.Api;
using Kernel.DTO;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<List<ProductResponse>> Get()
    {
        ApiBase mercadoLivre = ApiBase.Instance("mercado-livre");
        //ApiBase amazon = ApiBase.Instance("amazon");
        
        var resp = await mercadoLivre.SearchProduct();
        //var resp = await amazon.SearchProduct();
        
        return resp;
    }

    public async Task<string> GetProduct(string id, string store)
    {
        ApiBase mercadoLivre = ApiBase.Instance(store);
        return await mercadoLivre.GetProduct(id);
    }
}