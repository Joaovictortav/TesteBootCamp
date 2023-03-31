namespace Kernel.Api;

public class Charlinhos : ApiBase
{
    public Charlinhos(string baseUrl) : base(baseUrl)
    {
    }

    public override Task<string> SearchProduct()
    {
        throw new NotImplementedException();
    }
}