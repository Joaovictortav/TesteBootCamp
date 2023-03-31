using Kernel.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Facadee.Facade;

[ApiController]    
[Route("V1/Busca", Name = "Busca")]	
[Produces("application/json")]

public class Busca: FacadeBase
{
    public Busca()
    {
    }
    
    [HttpGet, Route("Get")] 
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)] 
    public async Task<IActionResult> VerifyToken([FromHeader(Name = "AuthToken")] string authToken) 
    { 
        try 
        {
            return Ok(await new BuscaController().Get()); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
}