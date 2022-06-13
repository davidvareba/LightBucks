namespace LightBucks.Models
{
    public class Snack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Descriptions { get; set; }
        public string ImgUrl { get; set; }
        public int SnackId { get; set; }
        public int UserId { get; set; }
    }
}
