using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Users
{
    public class UsersEditViewModel:BaseEntity
    {
        [Required]
        [StringLength(160, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 160")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 30")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please input a name! It is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 20")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Name can consist of letters, spaces and dashes only!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input a phone! It is required!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 40")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone must be 10 digits")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public bool IsAdmin { get; set; }
    }
}