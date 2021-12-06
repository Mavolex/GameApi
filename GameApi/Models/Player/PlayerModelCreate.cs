using System.ComponentModel.DataAnnotations;

namespace GameApi.Models.Player
{
    public class PlayerModelCreate
    {
        [Required]
        public string Username  { get; set; }
        [Required]
        public string Email  { get; set; }
        [Required]
        public string Password  { get; set; }
    }
}
