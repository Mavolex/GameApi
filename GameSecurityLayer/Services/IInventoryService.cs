using GameSecurityLayer.Models.Inventory;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public interface IInventoryService
    {
        InventoryModel Get(int Id);
        Task AddItem(int playerId, int ItemId, int count);
        Task RemoveItem(int playerId, int ItemId, int count);
    }
}
