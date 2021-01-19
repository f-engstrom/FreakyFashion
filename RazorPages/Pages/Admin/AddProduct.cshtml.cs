using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Compression;
using System.Linq;
using FreakyFashion.Data;
using FreakyFashion.RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.RazorPages.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        private readonly FreakyFashionContext _context;

        public AddProductModel(FreakyFashionContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Categories { get; set; }
        public Clothing Clothing = new Clothing();

        public IActionResult OnGet()
        {
            Categories = _context.Category.Select(a =>
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                }).ToList();

            return Page();


        }


        public IActionResult OnPost(Clothing clothing)
        {


            _context.Add(clothing);
            _context.SaveChanges();

            return RedirectToPage("ListProducts");

        }

        
        public class ClothingDTO
        {
            public string Name { get; set; }

            public string Description { get; set; }

            [Column(TypeName = "decimal(19,4)")]
            public decimal Price { get; set; }

            [DataType(DataType.ImageUrl)]
            [Display(Name = "Image URL")]
            public string ImageUrl { get; set; }

            public int CategoryId { get; set; }
            public Category Category { get; set; }

            [Display(Name = "Climate Compensated")]
            public bool ClimateCompensated { get; set; }

        }

    }
}