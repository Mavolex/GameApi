using GameApi.Models.Player;
using GameSecurityLayer.Models.Inventory;
using GameSecurityLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {

        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Find inventory entity with the given player id
        /// </summary>
        [HttpGet("{ID}")]
        public InventoryModel Get(int ID)
        {
            return _inventoryService.Get(ID);
        }

        /// <summary>
        /// Add item to inventory
        /// </summary>
        [HttpPut]
        public async Task AddItem(InventoryModelAdd model)
        {
            await _inventoryService.AddItem(model.PlayerId, model.ItemId, model.Count);
        }

        /// <summary>
        /// Delete item from inventory
        /// </summary>
        [HttpPut("{playerId}")]
        public async Task RemoveItem(int playerId, InventoryModelAdd model)
        {
            if (playerId != model.PlayerId)
                throw new InvalidOperationException("Bad data");

            await _inventoryService.RemoveItem(model.PlayerId, model.ItemId, model.Count);
        }
    }
}
