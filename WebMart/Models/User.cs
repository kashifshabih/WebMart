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
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public Address Address { get; set; }

        public virtual ICollection<CreditCard> CreditCards { get; set; }        
    }
}