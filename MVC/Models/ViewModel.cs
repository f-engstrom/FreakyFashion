using System.Collections.Generic;
using FreakyFashion.Models;

namespace FreakyFashion.MWC.Models
{
    public class ViewModel
    {
        public IEnumerable<Clothing> Clothing { get; set; }
        public IEnumerable<Category> Category { get; set; }

        public Clothing ClothingItem { get; set; }
    }
}
