using System;
using System.Numerics;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebMart.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Please enter correct name")]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Please enter correct name")]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"[1-9][0-9]{9}", ErrorMessage = "Please enter correct phone number")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [Required]
        public Address Address { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }        
    }
}