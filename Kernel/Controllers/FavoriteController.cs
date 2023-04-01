using Kernel.DTO;
using Kernel.Model;

namespace Kernel.Controllers;

public class FavoriteController
{
    public async Task<bool> Favorite(UserFavorite userRequest)
    {
        await using var context = BootcampContext.Get();

        var it = Favorites.GetFavorites(name: userRequest.name!);
        _ = new Favorites(userRequest);   
        
        await context.SaveChangesAsync();
        return true;  
    }
    public async Task<bool> ListFavorites(UserFavorite userRequest)
    {
        await using var context = BootcampContext.Get();
        await Favorites.ListFavorites();
        return true;
    }
}