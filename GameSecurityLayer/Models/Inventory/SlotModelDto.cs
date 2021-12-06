using GameSecurityLayer.Models.Items;

namespace GameSecurityLayer.Models.Inventory
{
    public class SlotModelDto
    {
        public ItemModel Item { get; set; }
        public int PlayerId { get; set; }
        public int ItemQuantity { get; set; }
    }
}
