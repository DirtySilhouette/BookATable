using System;
using System.ComponentModel.DataAnnotations;
using BookATable.Entity;

namespace BookATable.Entity
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        
        [Range(1, 100), Required]
        public int PeopleCount { get; set; }

        public DateTime ReservationTime { get; set; }

        public string Comment { get; set; }

        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}