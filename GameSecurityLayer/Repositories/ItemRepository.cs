using GameSecurityLayer.Contexts;
using GameSecurityLayer.Models.Items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public class ItemRepository<ItemModel> : IItemRepository<ItemModel>
    {
        private readonly GameContext _context;

        public ItemRepository(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<ItemModelDto> GetAllList()
        {
            return _context.Items.Select(p => new ItemModelDto()
            {
                _id = p._id,
                Name = p.Name,
                Description = p.Description,
                Rarity = p.Rarity,
            }).ToList();
        }

        public async Task<ItemModelDto> Get(int Id)
        {
            var model = await _context.Items.FindAsync(Id);

            return new ItemModelDto()
            {
                _id = model._id,
                Name = model.Name,
                Description = model.Description,
                Rarity = model.Rarity,
            };
        }

        public async Task Add(ItemModelDto model)
        {
            try
            {
                await _context.Items.AddAsync(new Models.Items.ItemModel()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Rarity = model.Rarity,
                });
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }

    }
}
