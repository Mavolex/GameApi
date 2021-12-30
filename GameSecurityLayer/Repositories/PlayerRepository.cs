using AutoMapper;
using GameSecurityLayer.Contexts;
using GameSecurityLayer.Models.Player;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GameContext _context;
        private readonly IMapper _mapper;

        public PlayerRepository(GameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<PlayerModelDto> GetAllList()
        {
            return _context.Players.Select(p => _mapper.Map<PlayerModel, PlayerModelDto>(p));
        }

        public async Task<PlayerModelDto> Get(int Id)
        {
            var model = await _context.Players.FindAsync(Id);

            return _mapper.Map<PlayerModel, PlayerModelDto>(model);
        }

        public async Task Add(PlayerModelDto model)
        {

            await _context.Players.AddAsync(_mapper.Map<PlayerModelDto, PlayerModel>(model));
            await _context.SaveChangesAsync();
        }

        public async Task<PlayerModelDto> Hit(int Id, IInventoryRepository inventory)
        {
            var model = _context.Players.Where(p => p._id == Id).FirstOrDefault();
            model.Score += inventory.Damage(Id) + 1;
            _context.Players.Update(model);
            await _context.SaveChangesAsync();
            return _mapper.Map<PlayerModel, PlayerModelDto>(model);
        }

        public async Task<bool> Withdraw(int playerId, int summ)
        {
            var model = _context.Players.Where(p => p._id == playerId).FirstOrDefault();
            if (model.Score < summ) { 
                return false;
            }
            model.Score -= summ;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return true;




        }
    }
}
