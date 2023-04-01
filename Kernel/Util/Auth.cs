namespace Kernel.Util;

public class Auth
{
    public static async Task Verify(string token)
    {
        var rc = new RestClient("https://localhost:7099/", "GET");

        Dictionary<string, string> header = new()
        {
            {"AuthToken", token}
        };
        
        var result = await rc.Run("V1/Auth/VerifyToken", null, header);

        if (string.IsNullOrEmpty(result))
        {
            throw new Exception("Token invalido");
        }
    }
}