using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.News.Models
{
    public class _Settings
    {
        public static void ClearCookies()
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("admin"))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["admin"];
                cookie.Value = "admin";
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                HttpContext.Current.Request.Cookies.Add(cookie);
            }
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("user"))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["user"];
                cookie.Value = "user";
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
                HttpContext.Current.Request.Cookies.Add(cookie);
            }
        }




        public static void AddUser(int userID)
        {
            HttpCookie cookie = new HttpCookie("user");
            cookie.Value = userID.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Request.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }




        public static void AddAdmin(int userID)
        {
            HttpCookie cookie = new HttpCookie("admin");
            cookie.Value = userID.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Request.Cookies.Add(cookie);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }




        public static bool IsAdmin
        {
            get
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("admin"))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public static bool IsUser
        {
            get
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("user"))
                {
                    return true;
                }
                else if (HttpContext.Current.Request.Cookies.AllKeys.Contains("admin"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Int32 UserID
        {
            get
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains("user"))
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["user"].Value);
                }
                else if (HttpContext.Current.Request.Cookies.AllKeys.Contains("admin"))
                {
                    return Convert.ToInt32(HttpContext.Current.Request.Cookies["admin"].Value);
                }
                else
                {
                    return 0;
                }
            }

        }

    }
}