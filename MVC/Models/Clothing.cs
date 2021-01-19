using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreakyFashion.Models
{
    public class Clothing
    {
        public int Id { get; set; }
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

        public List<ClothesSizes> Sizes { get; set; } = new List<ClothesSizes>();
     
    }
}
