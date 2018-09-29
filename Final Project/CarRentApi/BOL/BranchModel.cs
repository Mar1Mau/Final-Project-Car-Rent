

using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class BranchModel
    {
        [Required, MinLength(5), MaxLength(100)]
        public string FullAddress { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string BranchName { get; set; }

    }
}
