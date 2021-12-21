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

            return new PlayerModelDto() {
                _id = model._id,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };
        }

        public async Task Add(PlayerModelDto model)
        {

            await _context.Players.AddAsync(new PlayerModel()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            });
            await _context.SaveChangesAsync();
        }
    }
}
