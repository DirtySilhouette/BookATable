using BookATable.Data.Repositories;
using BookATable.Entity;
using BookATable.Filters;
using BookATable.ViewModels.Users;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookATable.Controllers
{


    public class UsersController : Controller
    {
        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Index()
        {
            UserRepository repository = new UserRepository();
            List<User> users = repository.GetAll();

            UsersListViewModel model = new UsersListViewModel();
            model.Users = users;

            return View(model);
        }

        [AuthenticationFilter(RequireAdminRole = true)]
        public ActionResult Create()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Create(UsersCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Phone = model.Phone;
            user.IsAdmin = model.IsAdmin;

            var repository = new UserRepository();
            repository.Insert(user);

            return RedirectToAction("Index");
        }


        [AuthenticationFilter(RequireAdminRole = true)]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            UserRepository repository = new UserRepository();

            UsersEditViewModel model = new UsersEditViewModel();

            if (id.HasValue)
            {
                User user = repository.GetByID(id.Value);
                model.ID = user.ID;
                model.Name = user.Name;
                model.Email = user.Email;
                model.Password = user.Password;
                model.Phone = user.Phone;
                model.IsAdmin = user.IsAdmin;
            }

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserRepository repository = new UserRepository();

            User user = new User();
            user.ID = model.ID;
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Phone = model.Phone;
            user.IsAdmin = model.IsAdmin;

            repository.Save(user);

            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UsersCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.Phone = model.Phone;
            user.IsAdmin = model.IsAdmin;

            var repository = new UserRepository();
            repository.Insert(user);

            return RedirectToAction("HomePage", "Home");
        }
        [AuthenticationFilter(RequireAdminRole = true)]
        [HttpGet]
        public ActionResult Delete(int id)
        {

            UserRepository repository = new UserRepository();

            User user = repository.GetByID(id);

            UsersDeleteViewModel model = new UsersDeleteViewModel();
            model.ID = user.ID;
            model.Name = user.Name;
            model.Email = user.Email;
            model.Password = user.Password;
            model.Phone = user.Phone;
            model.IsAdmin = user.IsAdmin;

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(UsersDeleteViewModel model)
        {

            UserRepository repository = new UserRepository();

            repository.Delete(model.ID);

            return RedirectToAction("Index");
        }
    }
}