using System.ComponentModel.DataAnnotations;

namespace GameApi.Models.Player
{
    public class ItemModelCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public int Price { get; set; }
        public int Damage { get; set; }
    }
}
