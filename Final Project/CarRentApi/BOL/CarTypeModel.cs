
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class CarTypeModel
    {
        [Required, MinLength(3), MaxLength(100)]
        public string ManufactrName { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Model { get; set; }

        [Required]
        public decimal DailyCost { get; set; }

        [Required]
         public decimal OverdueCostDay { get; set; }

        [Required, MinLength(4), MaxLength(10)]
        public string ManufactYear { get; set; }

        [Required]
        public bool IsManual { get; set; }

    }
}
