using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FreakyFashion.Data;
using FreakyFashion.Models;
using FreakyFashion.MWC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreakyFashion.MWC.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly FreakyFashionContext _context;

        public HomeController(FreakyFashionContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Clothing = _context.Clothing.ToList();
            viewModel.Category = _context.Category.ToList();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
