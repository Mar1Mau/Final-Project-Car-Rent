

using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class CarModel
    {
        [Required]
        public CarTypeModel CarType { get; set; }

        [Required]
        public int CurrentMileage { get; set; }

        [Required]
        public string Img { get; set; }

        [Required]
        public bool IsProperForRent { get; set; }

        [Required,MinLength(4), MaxLength(20)]
        public string CarNumber { get; set; }

        [Required]
        public BranchModel Branch { get; set; }
    }
}
