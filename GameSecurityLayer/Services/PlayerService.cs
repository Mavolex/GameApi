using GameSecurityLayer.Models.Player;
using GameSecurityLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository)
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
