using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreakyFashion.RazorPages.Pages
{
    public class ProductsModel :PageModel
    {
        private readonly FreakyFashionContext _context; 

        public ProductsModel(FreakyFashionContext context)
        {
            _context = context;
        }

        public Clothing Clothing {get; set;}

        public List<Clothing> Clothings { get; set; }

        public IActionResult OnGet(int id)
        {
            Clothing = _context.Clothing.FirstOrDefault(x => x.Id == id);
            Clothings = _context.Clothing.Take(4).ToList();

            if (Clothing == null)
            {
                return NotFound();
            }

            return Page();


        }


    }
}
