using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Models;
using FreakyFashion.MWC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashion.Controllers
{
    public class AdminController:Controller
    {

        private readonly FreakyFashionContext _context;

        public AdminController(FreakyFashionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Clothing = _context.Clothing;
            viewModel.Category = _context.Category;
            return View(viewModel);
        }
    }

    Regex rx = new Regex(@"\b(?<word>\w+)\s+(\k<word>)\b",
    RegexOptions.Compiled | RegexOptions.IgnoreCase); 
    string ding = "ding dong";

}

