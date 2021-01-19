using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FreakyFashion.Models
{
    public class Category
    {
       public int Id { get; set; }

       public string Name { get; set; }

       [Display(Name = "Image URL")]

        public string ImageUrl { get; set; }
       private List<Clothing> Clothing { get; set; } =new List<Clothing>();
    }
}