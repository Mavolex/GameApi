using System.Collections.Generic;

namespace GameSecurityLayer.Models.Inventory
{
    public class InventoryModel
    {
        public IEnumerable<SlotModelDto> Slots { get; set; }
    }
}
