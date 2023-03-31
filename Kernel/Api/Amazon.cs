using Kernel.Util;

namespace Kernel.Api;

public class Amazon : ApiBase
{
    static Amazon()
    {
    }

    public Amazon(string baseUrl) : base(baseUrl)
    {
    }

    public override Task<string> SearchProduct()
    {
        throw new NotImplementedException();
    }
}