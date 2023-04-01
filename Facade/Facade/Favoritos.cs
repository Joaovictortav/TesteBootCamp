using Kernel.Controllers;
using Kernel.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Facade;

[ApiController]    
[Route("V1/Favoritos", Name = "Favoritos")]	
[Produces("application/json")]

public class Favoritos : FacadeBase
{
    public Favoritos()
    {
    }

    [HttpPost, Route("Favorite")] 
    [ProducesResponseType(typeof(UserFavorite), StatusCodes.Status200OK)] 
    public async Task<IActionResult> Favorite([FromBody] UserFavorite userFavorite) 
    { 
        try 
        {
            return Ok(await new FavoriteController().Favorite(userFavorite)); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
    
    [HttpGet, Route("ListFavorites")] 
    [ProducesResponseType(typeof(UserFavorite), StatusCodes.Status200OK)] 
    public async Task<IActionResult> ListFavorites([FromBody] UserFavorite userFavorite) 
    { 
        try 
        {
            return Ok(await new FavoriteController().ListFavorites(userFavorite)); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
}