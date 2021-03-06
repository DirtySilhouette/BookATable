﻿using BookATable.Entity;
using System.Web;
using System.Web.Mvc;

namespace BookATable.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public AuthenticationFilter()
        {
            RequireAdminRole = false;
        }

        public bool RequireAdminRole { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            User user = (User)HttpContext.Current.Session["LoggedUser"];

            if (user == null)
            {
                filterContext.Result = new RedirectResult("/Home/HomePage");
                return;
            }

            if (RequireAdminRole == true && user.IsAdmin != true)
            {
                filterContext.Result = new RedirectResult("/Home/HomePage");
                return;
            }
        }
    }
}