using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kernel.DTO;
using Microsoft.EntityFrameworkCore;

namespace Kernel.Model
{
    [Table("favorites")]
    public sealed class Favorites
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ID", TypeName = "INT")] public int Id { get; set; } 
        [Column("user", TypeName = "VARCHAR(36)"), MaxLength(255), Required] public string? User { get; set; } 
        [Column("product_id", TypeName = "VARCHAR(255)"), MaxLength(255), Required] public string? ProductId { get; set; } 
        [Column("store", TypeName = "VARCHAR(100)"), MaxLength(100), Required] public string? Store { get; set; } 
        [Column("status", TypeName = "BIT"), Required] public bool Status { get; set; } 

        public Favorites() { }
        public Favorites (UserFavorite userFavorite)
        {
            User = userFavorite.name;
            ProductId = userFavorite.productId;
            Store = userFavorite.store;
            Status = true;
            
            BootcampContext.Get().FavoriteSet.Add(this);
        }
        internal void Delete()
        {
            BootcampContext.Get().FavoriteSet.Remove(this);
        }
        public static async Task<UserFavorite?> ListFavorites()
        {
            IQueryable<Favorites> set = BootcampContext.Get().FavoriteSet;

            
            throw new NotImplementedException();
        }
        public static Task<Favorites?> GetFavorites(string? name = null, string? id = null, string? store = null)
        {
            return BootcampContext.Get().FavoriteSet.FirstOrDefaultAsync(s => s.User == name && s.ProductId == id && s.Store == store);
        }
    }
}