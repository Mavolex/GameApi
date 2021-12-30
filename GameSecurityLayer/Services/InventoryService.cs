using GameSecurityLayer.Models.Inventory;
using GameSecurityLayer.Repositories;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IPlayerRepository _player;
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository, IPlayerRepository player)
        {
            _repository = repository;
            _player = player;
        }

        public InventoryModel Get(int Id)
        {
            return _repository.Get(Id);
        }

        public async Task AddItem(int playerId, int ItemId, int count)
        {
            await _repository.AddItem(playerId, ItemId, count, _player);
        }

        public async Task RemoveItem(int playerId, int ItemId, int count)
        {
            await _repository.RemoveItem(playerId, ItemId, count);
        }
    }
}
