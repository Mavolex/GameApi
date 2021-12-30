using GameSecurityLayer.Models.Player;
using GameSecurityLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _player;
        private readonly IInventoryRepository _inventory;

        public PlayerService(IPlayerRepository player, IInventoryRepository inventory)
        {
            _player = player;
            _inventory = inventory;
        }

        public IEnumerable<PlayerModelDto> GetAllList() 
        {
            return _player.GetAllList();
        }

        public Task<PlayerModelDto> Get(int Id)
        {
            return _player.Get(Id);
        }

        public async Task Add(PlayerModelDto model)
        {
            await _player.Add(model);
        }

        public async Task<PlayerModelDto> Hit(int Id)
        {
            return await _player.Hit(Id, _inventory);
        }
    }
}
