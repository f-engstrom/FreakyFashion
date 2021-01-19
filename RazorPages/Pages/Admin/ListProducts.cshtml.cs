using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using FreakyFashion.Data;
using FreakyFashion.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.RazorPages.Pages.Admin
{
    public class ListProductsModel :PageModel
    {
        private readonly FreakyFashionContext _context; 

        public ListProductsModel(FreakyFashionContext context)
        {
            _context = context;
        }

        public List<Clothing> Clothing {get; set;}

        public IActionResult OnGet(int id)
        {
            Clothing = _context.Clothing.Include(x=> x.Category).ToList();

            if (Clothing == null)
            {
                return NotFound();
            }

            return Page();


        }


    }
}
