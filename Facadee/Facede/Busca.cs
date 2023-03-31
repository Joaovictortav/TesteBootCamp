using Microsoft.AspNetCore.Mvc;
namespace Facadee.Facede;

[ApiController]    
[Route("V1/Busca", Name = "Busca")]	
[Produces("application/json")]

public class Busca: FacadeBase
{
    public Busca()
    {
    }
    
    
}