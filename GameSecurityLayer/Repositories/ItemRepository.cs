using AutoMapper;
using GameSecurityLayer.Contexts;
using GameSecurityLayer.Models.Items;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly GameContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(GameContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<ItemModelDto> GetAllList()
        {
            return _context.Items.Select(p => _mapper.Map<ItemModel, ItemModelDto>(p));
        }

        public async Task<ItemModelDto> Get(int Id)
        {
            var model = await _context.Items.FindAsync(Id);
            return _mapper.Map<ItemModel, ItemModelDto>(model);
        }

        public async Task Add(ItemModelDto model)
        {
            await _context.Items.AddAsync(_mapper.Map<ItemModelDto, ItemModel>(model));
            await _context.SaveChangesAsync();
        }

    }
}
