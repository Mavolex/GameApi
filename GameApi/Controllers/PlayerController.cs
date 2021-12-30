using GameApi.Models.Player;
using GameSecurityLayer.Models.Player;
using GameSecurityLayer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Get a collection of all players
        /// </summary>
        [HttpGet]
        public IEnumerable<PlayerModelDto> GetAllList()
        {
            return _playerService.GetAllList();
        }

        /// <summary>
        /// Find a player entity with the given id
        /// </summary>
        [HttpGet("{ID}")]
        public Task<PlayerModelDto> Get(int ID)
        {
            return _playerService.Get(ID);
        }

        /// <summary>
        /// Create a new player entity
        /// </summary>
        [HttpPost]
        public async Task Add(PlayerModelCreate model)
        {
            await _playerService.Add(new PlayerModelDto() { 
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            });
        }

        /// <summary>
        /// Hit
        /// </summary>
        [HttpPost("{ID}")]
        public async Task<PlayerModelDto> Hit(int ID)
        {
            return await _playerService.Hit(ID);
        }
    }
}
