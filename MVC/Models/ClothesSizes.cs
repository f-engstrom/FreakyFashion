namespace FreakyFashion.Models
{
    public class ClothesSizes
    {
        public int ClothingId { get; set; }
        public int SizeId { get; set; }

        public  Clothing Clothing { get; set; }
        public  Size  Size { get; set; }

    }
}