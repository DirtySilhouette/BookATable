using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATable.ViewModels.Restaurants
{
    public class RestaurantsCreateViewModel:BaseEntity
    {
        [Required(ErrorMessage = "Please input a name.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 20")]
        [RegularExpression(@"^([A-z -]+)$", ErrorMessage = "Name can consist of letters, spaces and dashes only!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please input an address.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 40")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please input a phone number.")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Minimum length is 3 and maximum length is 40")]
        public string Phone { get; set; }

        public int Capacity { get; set; }

        //Required(ErrorMessage = "Please input a Open hour! It is required!")]
        public DateTime OpenHour { get; set; }

        //[Required(ErrorMessage = "Please input a Close hour! It is required!")]
        public DateTime CloseHour { get; set; }

    }
}