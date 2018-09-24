using System;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class UserModel
    {
        [Required, MinLength(3), MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [IdValidator]
        public string IdCard { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string UserName { get; set; }

        
        public DateTime? DoB { get; set; }

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Passwd { get; set; }

        [Required]
        public UserRoleModel Role { get; set; }

        
        public string Img { get; set; }



    }
}
