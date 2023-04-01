using Kernel.DTO;
using Kernel.Model;

namespace Kernel.Controllers;

public class FavoriteController
{
    public async Task<bool> AddFavorite(UserFavorite userRequest)
    {
        await using var context = BootcampContext.Get();

        var it = await Favorites.GetFavorites(id: userRequest.productId!);
        if (it is not null)
            throw new Exception("Favorite item already registered in database");

        _ = new Favorites(userRequest);   
        
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveFavorite(UserFavorite userRequest)
    {
        await using var context = BootcampContext.Get();
        await Favorites.Delete();
        return true;
    }
    public async Task<bool> ListFavorites(UserFavorite userRequest)
    {
        await using var context = BootcampContext.Get();
        await Favorites.ListFavorites();
        return true;
    }
    public async Task<bool> Redirect(UserFavorite userRequest)
    {
        await using var context = BootcampContext.Get();
        await Favorites.Redirect(id: userRequest.productId!);
        return true;
    }
}