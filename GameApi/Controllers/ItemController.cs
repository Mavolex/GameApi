using GameApi.Models.Player;
using GameSecurityLayer.Models.Items;
using GameSecurityLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {

        private readonly IItemService<ItemModel> _itemService;

        public ItemController(IItemService<ItemModel> itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Get a collection of all items
        /// </summary>
        [HttpGet]
        public IEnumerable<ItemModelDto> GetAllList()
        {
            return _itemService.GetAllList();
        }

        /// <summary>
        /// Find a item entity with the given id
        /// </summary>
        [HttpGet("{ID}")]
        public Task<ItemModelDto> Get(int ID)
        {
            return _itemService.Get(ID);
        }

        /// <summary>
        /// Create a new item entity
        /// </summary>
        [HttpPost]
        public async Task Add(ItemModelCreate model)
        {
            await _itemService.Add(new ItemModelDto()
            {
                Name = model.Name,
                Description = model.Description,
                Rarity = model.Rarity,
            });
        }
    }
}
