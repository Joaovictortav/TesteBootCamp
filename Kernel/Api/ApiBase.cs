using Kernel.Util;

namespace Kernel.Api;

public abstract class ApiBase
{
    protected string baseUrl;

    private static readonly Dictionary<string, Type> ApiMap = new Dictionary<string, Type>()
    {
        { "amazon", typeof(Amazon) },
        { "mercado-livre", typeof(MercadoLivre) },
        { "charlinhos", typeof(Charlinhos) }
    };

    public ApiBase(string baseUrl)
    {
        this.baseUrl = baseUrl;
    }

    public static ApiBase Instance(string name)
    {
        if (!ApiMap.ContainsKey(name))
            throw new Exception("Monitor invalido");

        var ci = ApiMap[name].GetConstructor( Array.Empty<Type>() );
        return (ApiBase)ci?.Invoke(new object[]{  })!;
    }
    public abstract Task<string> SearchProduct();
    public abstract Task<string> GetProduct(string id);
    
}