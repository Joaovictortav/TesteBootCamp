using Kernel.Api;
using Kernel.DTO;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<List<ProductResponse>> Get(string name)
    {
        var result = new List<ProductResponse>();
        ApiBase mercadoLivre = ApiBase.Instance("mercado-livre");
        ApiBase amazon = ApiBase.Instance("amazon");
        
        var respMercadoLivre = await mercadoLivre.SearchProduct(name);
        var respAmazon = await amazon.SearchProduct(name);
        
        result.AddRange(respMercadoLivre);
        result.AddRange(respAmazon);
        
        return result;
    }

    public async Task<ProductDetail> GetProduct(string id, string store)
    {
        ApiBase mercadoLivre = ApiBase.Instance(store);
        return await mercadoLivre.GetProduct(id);
    }
}