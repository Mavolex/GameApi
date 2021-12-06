using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSecurityLayer.Models.Inventory
{
    public class SlotModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public int ItemId { get; set; }
        public int PlayerId { get; set; }
        public int ItemQuantity { get; set; }

    }
}
