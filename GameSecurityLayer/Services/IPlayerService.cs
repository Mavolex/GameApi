using GameSecurityLayer.Models.Player;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public interface IPlayerService
    {
        IEnumerable<PlayerModelDto> GetAllList();
        Task<PlayerModelDto> Get(int Id);
        Task Add(PlayerModelDto model);
    }
}
