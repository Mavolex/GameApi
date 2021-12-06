using GameSecurityLayer.Contexts;
using GameSecurityLayer.Models.Player;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public class PlayerRepository<PlayerModel> : IPlayerRepository<PlayerModel>
    {
        private readonly GameContext _context;

        public PlayerRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<PlayerModelDto> GetAllList()
        {
            return _context.Players.Select(p => new PlayerModelDto()
            {
                _id = p._id,
                Username = p.Username,
                Email = p.Email,
                Password = p.Password
            }).ToList();
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

            await _context.Players.AddAsync(new Models.Player.PlayerModel()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            });
            await _context.SaveChangesAsync();
        }
    }
}
