using BookATable.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATable.Filters
{
    public static class AdminFilter
    {
        public static bool IsAdmin()
        {
            User user = (User)HttpContext.Current.Session["LoggedUser"];

            if (user != null)
            {
                if (user.IsAdmin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("/Home/HomePage");
                return false;
            }
        }

        public static bool IsNotLoggedUser()
        {
            if (HttpContext.Current.Session["LoggedUser"] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}