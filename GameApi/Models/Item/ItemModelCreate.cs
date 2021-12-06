using System.ComponentModel.DataAnnotations;

namespace GameApi.Models.Player
{
    public class ItemModelCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Rarity { get; set; }
    }
}
