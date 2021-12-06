using GameSecurityLayer.Models.Player;
using GameSecurityLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public class PlayerService<PlayerModel> : IPlayerService<PlayerModel>
    {
        private readonly IPlayerRepository<PlayerModel> _repository;

        public PlayerService(IPlayerRepository<PlayerModel> repository)
        { 
            _repository = repository;
        }

        public IEnumerable<PlayerModelDto> GetAllList() 
        {
            return _repository.GetAllList();
        }

        public Task<PlayerModelDto> Get(int Id)
        {
            return _repository.Get(Id);
        }

        public async Task Add(PlayerModelDto model)
        {
            await _repository.Add(model);
        }
    }
}
