using Kernel.DTO;

namespace Kernel.Api;

public class Charlinhos : ApiBase
{
    public Charlinhos(string baseUrl) : base(baseUrl)
    {
    }

    public override Task<List<ProductResponse>> SearchProduct(string name)
    {
        throw new NotImplementedException();
    }

    public override Task<ProductDetail> GetProduct(string id)
    {
        throw new NotImplementedException();
    }
}