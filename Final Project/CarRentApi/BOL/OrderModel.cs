using System;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class OrderModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

       
        public DateTime? ActualReturnDate { get; set; }

        [Required]
        public UserModel User { get; set; }

        [Required]
        public CarModel Car { get; set; }

    }
}
