using GameSecurityLayer.Models.Items;
using GameSecurityLayer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public class ItemService<ItemModel> : IItemService<ItemModel>
    {
        private readonly IItemRepository _repository;

        public ItemService(IItemRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ItemModelDto> GetAllList()
        {
            return _repository.GetAllList();
        }

        public Task<ItemModelDto> Get(int Id)
        {
            return _repository.Get(Id);
        }

        public async Task Add(ItemModelDto model)
        {
            await _repository.Add(model);
        }
    }
}
