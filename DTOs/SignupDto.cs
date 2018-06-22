using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class SignupDto
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(10)]
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Country_id { get; set; }
        [Required]
        [RegularExpression("^(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,10}$")]
        public string Password { get; set; }
    }
}
