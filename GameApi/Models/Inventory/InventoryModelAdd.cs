using System.ComponentModel.DataAnnotations;

namespace GameApi.Models.Player
{
    public class InventoryModelAdd
    {
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
