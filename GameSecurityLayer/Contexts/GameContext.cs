using GameSecurityLayer.Models.Inventory;
using GameSecurityLayer.Models.Items;
using GameSecurityLayer.Models.Player;
using Microsoft.EntityFrameworkCore;

namespace GameSecurityLayer.Contexts
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }

        public DbSet<PlayerModel> Players { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<SlotModel> Slots { get; set; }
    }
}
