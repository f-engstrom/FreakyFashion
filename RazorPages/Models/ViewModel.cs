using System.Collections.Generic;

namespace FreakyFashion.RazorPages.Models
{
    public class ViewModel
    {
        public IEnumerable<Clothing> Clothing { get; set; }
        public IEnumerable<Category> Category { get; set; }


    }
}
