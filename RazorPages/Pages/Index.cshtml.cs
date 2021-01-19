using FreakyFashion.Data;
using FreakyFashion.RazorPages.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace FreakyFashion.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly FreakyFashionContext _context;

        public IndexModel(FreakyFashionContext context)
        {
            _context = context;
        }


        public List<Category> Categories { get; set; }
        public List<Clothing> Clothings { get; set; }

        public void OnGet()
        {

            Categories = _context.Category.ToList();
            Clothings = _context.Clothing.Take(8).ToList();


        }
    }
}
