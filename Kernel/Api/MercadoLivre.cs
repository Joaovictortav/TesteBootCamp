using Kernel.DTO;
using Kernel.DTO.Amazon;
using Kernel.DTO.MercadoLivre;
using Kernel.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kernel.Api;

public class MercadoLivre : ApiBase
{
    private readonly Dictionary<string, string> header = new Dictionary<string, string>()
    {
        { "Authorization", "Bearer 0UgEpizqJM7CSl3O9nbIzrTvTuaU2JZG" },
    };
    public MercadoLivre() : base("https://api.mercadolibre.com/")
    {
    }

    public override async Task<List<ProductResponse>> SearchProduct(string name)
    {
        var t = new RestClient(baseUrl, "GET");
        var param = new Dictionary<string, object>();

        param.TryAdd("q", name);
        param.TryAdd("status", "active");

        var result = await t.Run("sites/MLB/search", param);
        var ret = JsonConvert.DeserializeObject<List<ProductML>>(JObject.Parse(result).GetValue("results")!.ToString());
        return ConvertObject(ret);
    }

    private List<ProductResponse> ConvertObject(List<ProductML> products)
    {
        var retorno = new List<ProductResponse>();
        foreach (var p in products)
        {
            retorno.Add(new ProductResponse()
            {
                price = p.price,
                stockQuantity = p.sold_quantity,
                description = p.title,
                provider = "mercado-livre",
                link = p.thumbnail,
                id = p.catalog_product_id
            });
        }

        return retorno;
    }

    public override async Task<ProductDetail> GetProduct(string id)
    {
        var t = new RestClient(baseUrl, "GET");
        var result = await t.Run($"/products/{id}", headers: header);
        
        var ret = JsonConvert.DeserializeObject<DetailML>(result);
        return ConvertDetail(ret);
    }

    private ProductDetail ConvertDetail(DetailML detail)
    {
        return new ProductDetail()
        {
            Detalhe = detail.short_description?.content!,
            Domain = detail.domain_id,
            Link = detail.permalink,
            Name = detail.name
        };
    }
}