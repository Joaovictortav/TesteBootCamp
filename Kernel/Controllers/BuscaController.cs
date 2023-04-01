using Kernel.Api;
using Kernel.DTO;
using Kernel.Util;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<List<ProductResponse>> Get(string authToken, string name)
    {

        await Auth.Verify(authToken);
        var result = new List<ProductResponse>();
        ApiBase mercadoLivre = ApiBase.Instance("mercado-livre");
        ApiBase amazon = ApiBase.Instance("amazon");
        
        var respMercadoLivre = await mercadoLivre.SearchProduct(name);
        var respAmazon = await amazon.SearchProduct(name);
        
        result.AddRange(respMercadoLivre);
        result.AddRange(respAmazon);
        
        return result;
    }
    public async Task<ProductDetail> GetProduct(string authToken, string id, string store)
    {
        await Auth.Verify(authToken);
        ApiBase mercadoLivre = ApiBase.Instance(store);
        return await mercadoLivre.GetProduct(id);
    }
    public async Task<ProductDetail> Favorite()
    {
        throw new NotImplementedException();
    }
    
}