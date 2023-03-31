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
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] 
    public async Task<IActionResult> Get() 
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
    
    [HttpGet, Route("GetProduct")] 
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)] 
    public async Task<IActionResult> GetProduct([FromQuery] string id, [FromQuery] string store) 
    { 
        try 
        {
            return Ok(await new BuscaController().GetProduct(id, store)); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
}