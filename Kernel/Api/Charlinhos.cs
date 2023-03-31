using Kernel.DTO;

namespace Kernel.Api;

public class Charlinhos : ApiBase
{
    public Charlinhos(string baseUrl) : base(baseUrl)
    {
    }

    public override Task<List<ProductResponse>> SearchProduct()
    {
        throw new NotImplementedException();
    }

    public override Task<string> GetProduct(string id)
    {
        throw new NotImplementedException();
    }
}