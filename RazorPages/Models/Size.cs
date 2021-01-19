using System.Collections.Generic;

namespace FreakyFashion.RazorPages.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string ItemSize { get; set; }


        public List<ClothesSizes> Clothes { get; set; } = new List<ClothesSizes>();
    }
}
