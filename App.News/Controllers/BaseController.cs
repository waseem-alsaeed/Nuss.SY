using App.Entity;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.News.Controllers
{
    public class BaseController : Controller
    {
        public static string conectionString = @"Data Source=DESKTOP-2DH1V9A\SQLEXPRESS;Initial Catalog=News;Integrated Security=True";
        public TData<App.Models.Slider> _Slider = new TData<App.Models.Slider>(conectionString);
        public TData<App.Models.News> _News = new TData<App.Models.News>(conectionString);
        public TData<App.Models.Videos> _Videos = new TData<App.Models.Videos>(conectionString);
        public TData<App.Models.Departments> _Departments = new TData<App.Models.Departments>(conectionString);
        public TData<App.Models.Users> _Users = new TData<App.Models.Users>(conectionString);
        public TData<App.Models.Roles> _Roles = new TData<App.Models.Roles>(conectionString);

    }
}