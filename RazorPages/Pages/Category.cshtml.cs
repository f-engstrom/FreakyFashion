using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.RazorPages.Pages
{
    public class CategoryModel :PageModel
    {
        private readonly FreakyFashionContext _context; 

        public CategoryModel(FreakyFashionContext context)
        {
            _context = context;
        }

        public Category Category {get; set;}

        public IActionResult OnGet(int id)
        {
            Category = _context.Category.Include(x => x.Clothing).FirstOrDefault(x => x.Id == id);

            if (Category == null)
            {
                return NotFound();
            }

            return Page();


        }


    }
}
