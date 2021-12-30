namespace GameSecurityLayer.Models.Items
{
    public class ItemModelDto
    {
        public int _id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Damage { get; set; }
    }
}
