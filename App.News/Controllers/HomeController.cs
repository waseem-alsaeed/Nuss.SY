using App.Entity;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.News.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {

            var all = await _Slider.SelectAsync(new Entity.Models.StoredProcedure()
            {
                StoredProcedureName = "SP_Sliders"
            });


            var _GetVideos = await _Videos.SelectAsync(new Entity.Models.StoredProcedure()
            {
                StoredProcedureName = "SP_TopVideos"
            });



            ViewBag.Sliders = all.Data;
            ViewBag.lstVideos = _GetVideos.Data;

            return View();
        }


        public async Task<ActionResult> Detail(int ID)
        {
            var row = await _News.FindAsync(ID);
            return View(row.SingleData);
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Support()
        {
            return View();
        }


        public ActionResult Privacy()
        {
            return View();
        }


        public async Task<ActionResult> Categories()
        {
            var rows = await _Departments.SelectAsync();
               
            return View(rows.Data);
        }

        public async Task<ActionResult> AllNews(int ID)
        {
            var rows = await _News.SelectAsync(new Entity.Models.StoredProcedure()
            {
                StoredProcedureName = "GetAllNews",
                arr = new System.Collections.ArrayList() { ID },
                Params = new List<string>() { "ID" }
            });
            return View(rows.Data);
        }

    }
}