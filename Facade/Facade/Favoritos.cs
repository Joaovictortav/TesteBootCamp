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
    public async Task<IActionResult> GetFavorite([FromBody] UserFavorite userFavorite) 
    { 
        try 
        {
            return Ok(await new FavoriteController().AddFavorite(userFavorite)); 
        } 
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        } 
    }
    
    [HttpPost, Route("DeleteFavorite")] 
    [ProducesResponseType(typeof(UserFavorite), StatusCodes.Status200OK)] 
    public async Task<IActionResult> RemoveFavorite([FromBody] UserFavorite userFavorite) 
    { 
        try 
        {
            return Ok(await new FavoriteController().RemoveFavorite(userFavorite)); 
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