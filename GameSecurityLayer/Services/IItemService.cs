using GameSecurityLayer.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameSecurityLayer.Services
{
    public interface IItemService<ItemModel>
    {
        IEnumerable<ItemModelDto> GetAllList();
        Task<ItemModelDto> Get(int Id);
        Task Add(ItemModelDto model);
    }
}
