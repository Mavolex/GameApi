using GameSecurityLayer.Contexts;
using GameSecurityLayer.Models.Inventory;
using GameSecurityLayer.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSecurityLayer
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly GameContext _context;

        public InventoryRepository(GameContext context)
        {
            _context = context;
        }

        public async Task AddItem(int playerId, int ItemId, int count)
        {
            SlotModel model = _context.Slots.Where(s => s.PlayerId == playerId && s.ItemId == ItemId).FirstOrDefault();
            if (model == null)
            {
                await _context.Slots.AddAsync(new SlotModel()
                {
                    PlayerId = playerId,
                    ItemId = ItemId,
                    ItemQuantity = count
                });
                await _context.SaveChangesAsync();
                return;
            }
            model.ItemQuantity += count;
            _context.Slots.Update(model);
            await _context.SaveChangesAsync();

        }

        public InventoryModel Get(int Id)
        {
            IEnumerable<SlotModelDto> model = _context.Slots
                .Join(_context.Items,
                    slot => slot.ItemId,
                    item => item._id,
                    (slot, item) => new SlotModelDto()
                    {
                        PlayerId = slot.PlayerId,
                        Item = item,
                        ItemQuantity = slot.ItemQuantity,
                    })
                
                .Where(s => s.PlayerId == Id);

            InventoryModel Inventory = new() 
            { 
                Slots = model 
            };
            
            return Inventory;
        }

        public async Task RemoveItem(int playerId, int ItemId, int count)
        {
            SlotModel model = _context.Slots.Where(s => s.PlayerId == playerId && s.ItemId == ItemId).FirstOrDefault();
            if (model == null)
            {
                return;
            }

            if (model.ItemQuantity < count)
            {
                _context.Slots.Remove(model);
                await _context.SaveChangesAsync();
                return;
            }

            model.ItemQuantity -= count;
            _context.Slots.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
