﻿using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATable.ViewModels.Reservations
{
    public class ReservationsCreateViewModel
    {
        public int ID { get; set; }
       // public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int PeopleCount { get; set; }
        [Required(ErrorMessage = "Please input a Reservation Time! It is required!")]
        [DataType(DataType.Date)]
        public DateTime ReservationTime { get; set; }
        public string Comment { get; set; }
        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Restaurants { get; set; }
    }
}