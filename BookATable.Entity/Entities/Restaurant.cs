using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookATable.Entity
{
    public class Restaurant : BaseEntity
    {
        [StringLength(50, MinimumLength = 3), Required]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 5), Required]
        public string Address { get; set; }

        [StringLength(10, MinimumLength = 5), Required]
        public string Phone { get; set; }

        [Range(20, 1000), Required]
        public int Capacity { get; set; }

        [DataType(DataType.Time)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OpenHour { get; set; }

        [DataType(DataType.Time)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseHour { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}