using Kernel.Controllers;
using Kernel.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Facade;

[ApiController]    
[Route("V1/Busca", Name = "Busca")]	
[Produces("application/json")]

public class Busca: FacadeBase
{
    public Busca()
    {
    }
    
    [HttpGet, Route("Get")] 
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] 
    public async Task<IActionResult> Get([FromHeader(Name = "AuthToken")] string authToken, [FromQuery] string name) 
    { 
        try 
        {
            return Ok(await new BuscaController().Get(authToken, name)); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
    
    [HttpGet, Route("GetProduct")] 
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] 
    public async Task<IActionResult> GetProduct([FromHeader(Name = "AuthToken")] string authToken, [FromQuery] string id, [FromQuery] string store) 
    { 
        try 
        {
            return Ok(await new BuscaController().GetProduct(authToken, id, store)); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
}