using GameSecurityLayer.Models.Player;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public interface IPlayerRepository<PlayerModel>
    {
        IEnumerable<PlayerModelDto> GetAllList();
        Task<PlayerModelDto> Get(int Id);
        Task Add(PlayerModelDto model);
    }
}
