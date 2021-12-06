using GameSecurityLayer.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Repositories
{
    public interface IItemRepository<ItemModel>
    {
        IEnumerable<ItemModelDto> GetAllList();
        Task<ItemModelDto> Get(int Id);
        Task Add(ItemModelDto model);
    }
}
