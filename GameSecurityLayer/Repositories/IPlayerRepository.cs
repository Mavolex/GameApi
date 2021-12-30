using GameSecurityLayer.Models.Player;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public interface IPlayerRepository
    {
        IEnumerable<PlayerModelDto> GetAllList();
        Task<PlayerModelDto> Get(int Id);
        Task Add(PlayerModelDto model);
        Task<PlayerModelDto> Hit(int Id, IInventoryRepository _inventory);
        Task<bool> Withdraw(int playerId, int summ);
    }
}
