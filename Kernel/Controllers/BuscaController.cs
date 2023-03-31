using Kernel.Api;
using Kernel.Util;

namespace Kernel.Controllers;

public class BuscaController
{
    public async Task<string> Get()
    {
        // ApiBase b = new Amazon(Amazon.baseUrl);
        // ApiBase s = new MercadoLivre(MercadoLivre.baseUrl);

        ApiBase s = ApiBase.Instance("mercado-livre", "https://api.mercadolibre.com/");
        ApiBase b = ApiBase.Instance("amazon", "https://amazon23.p.rapidapi.com/");
        ApiBase r = ApiBase.Instance("charlinhos", "");
        
        var ret = await b.SearchProduct();
        var resp = await s.SearchProduct();
        var ret2 = await r.SearchProduct();
        
        
        
        return await Task.FromResult("");
    }
}