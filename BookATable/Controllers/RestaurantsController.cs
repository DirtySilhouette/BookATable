﻿using BookATable.Data.Repositories;
using BookATable.Entity;
using BookATable.Filters;
using BookATable.ViewModels.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookATable.Controllers
{
    public class RestaurantsController : Controller
    {
        public ActionResult Index()
        {
            RestaurantRepository repository = new RestaurantRepository();
            List<Restaurant> restaurants = repository.GetAll();

            RestaurantsListViewModel model = new RestaurantsListViewModel();
            model.Restaurants = restaurants;

            return View(model);
        }

        [AuthenticationFilter]
        public ActionResult Create()
        {
            return View();
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Create(RestaurantsCreateViewModel model)
        {

            Restaurant restaurant = new Restaurant();
            restaurant.Name = model.Name;
            restaurant.Address = model.Address;
            restaurant.Phone = model.Phone;
            restaurant.Capacity = model.Capacity;
            restaurant.OpenHour = model.OpenHour;
            restaurant.CloseHour = model.CloseHour;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var repository = new RestaurantRepository();
            repository.Insert(restaurant);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            RestaurantRepository repository = new RestaurantRepository();

            RestaurantsEditViewModel model = new RestaurantsEditViewModel();

            if (id.HasValue)
            {
                Restaurant restaurant = repository.GetByID(id.Value);
                model.ID = restaurant.ID;
                model.Name = restaurant.Name;
                model.Address = restaurant.Address;
                model.Phone = restaurant.Phone;
                model.Capacity = restaurant.Capacity;
                model.OpenHour = restaurant.OpenHour;
                model.CloseHour = restaurant.CloseHour;
            }

            return View(model);
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Edit(RestaurantsEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            RestaurantRepository repository = new RestaurantRepository();

            Restaurant restaurant = new Restaurant();
            restaurant.ID = model.ID;
            restaurant.Name = model.Name;
            restaurant.Address = model.Address;
            restaurant.Phone = model.Phone;
            restaurant.Capacity = model.Capacity;
            restaurant.OpenHour = model.OpenHour;
            restaurant.CloseHour = model.CloseHour;

            repository.Save(restaurant);

            return RedirectToAction("Index");
        }

        [AuthenticationFilter]
        [HttpGet]
        public ActionResult Delete(int id)
        {

            RestaurantRepository repository = new RestaurantRepository();

            Restaurant restaurant = repository.GetByID(id);

            RestaurantsDeleteViewModel model = new RestaurantsDeleteViewModel();
            model.ID = restaurant.ID;
            model.Name = restaurant.Name;
            model.Address = restaurant.Address;
            model.Phone = restaurant.Phone;
            model.Capacity = restaurant.Capacity;
            model.OpenHour = restaurant.OpenHour;
            model.CloseHour = restaurant.CloseHour;

            return View(model);
        }

        [AuthenticationFilter]
        [HttpPost]
        public ActionResult Delete(RestaurantsDeleteViewModel model)
        {

            RestaurantRepository repository = new RestaurantRepository();

            repository.Delete(model.ID);

            return RedirectToAction("Index");
        }
    }
}