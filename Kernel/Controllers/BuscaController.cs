using Kernel.Api;
using Kernel.Util;

namespace Kernel.Controllers;

public class BuscaController
{
    //https://docs.google.com/presentation/d/1zLe3pGjjyde49uv4Ld6HjyxTemnG9MPqIlSbXoUI6zg/edit#slide=id.g1e019cdf64b_7_60
    public async Task<string> Get()
    {
        // ApiBase b = new Amazon(Amazon.baseUrl);
        // ApiBase s = new MercadoLivre(MercadoLivre.baseUrl);

        // ApiBase mercadoLivre = ApiBase.Instance("mercado-livre", "https://api.mercadolibre.com/");
        ApiBase amazon = ApiBase.Instance("amazon");
        // ApiBase charlinhos = ApiBase.Instance("charlinhos", "");
        
        // var ret = await mercadoLivre.SearchProduct();
        var resp = await amazon.SearchProduct();
        // var ret2 = await charlinhos.SearchProduct();
        
        return await Task.FromResult("");
    }

    public async Task<string> GetProduct(string id, string store)
    {
        ApiBase amazon = ApiBase.Instance(store);

        var resp = await amazon.GetProduct(id);
        return await Task.FromResult("");
    }
}