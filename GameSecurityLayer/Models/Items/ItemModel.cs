using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSecurityLayer.Models.Items
{
    public class ItemModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rarity { get; set; }
    }
}
