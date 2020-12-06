using App.Entity;
using App.Entity.Structs;
using App.Models;
using App.News.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.News.Controllers
{
    [AllowAdmin]
    public class CPanelController : BaseController
    {
        // GET: CPanel
        public ActionResult Index()
        {
            ViewBag.NumberDepartment = _Departments.Select().Data.Count;
            ViewBag.NumberNews = _News.Select().Data.Count;
            ViewBag.NumberUsers = _Users.Select().Data.Count;
            ViewBag.NumberRoles = _Roles.Select().Data.Count;
            return View();
        }


        #region Departments
        public async Task<ActionResult> Departments()
        {
            var rows = await _Departments.SelectAsync();
            return View(rows.Data);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteDepartment(int ID)
        {
            var row = await _Departments.DeleteAsync(ID);
            return Json(row.Returened, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UploadImagesforDepartment()
        {
            var file = Request.Files["Filedata"];
            string savePath = Server.MapPath(@"~\Images\" + file.FileName);
            file.SaveAs(savePath);

            return Content(Url.Content(@"~\Images\" + file.FileName));
        }

        public ActionResult AddDepartment(int ID)
        {
            return View(ID == 0 ? new Departments() : _Departments.Find(ID).SingleData);
        }

        [HttpPost]
        public async Task<ActionResult> ExecuteDepartment(Departments model)
        {
            DbReturned<Departments> Insert_Update;
            if (model.DID == 0)
            {
                Insert_Update = await _Departments.InsertAsync(model);
            }
            else Insert_Update = await _Departments.UpdateAsync(model);
            return Json(Insert_Update.Returened, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region Users +  Roles + Videos + Sliders

        public async Task<ActionResult> Users()
        {
            var rows = await _Users.SelectAsync();
            return View(rows.Data);
        }


        public async Task<ActionResult> Roles()
        {
            var rows = await _Roles.SelectAsync();
            return View(rows.Data);
        }

        public async Task<ActionResult> Videos()
        {
            var rows = await _Videos.SelectAsync();
            return View(rows.Data);
        }

        public async Task<ActionResult> Sliders()
        {
            var rows = await _Slider.SelectAsync();
            return View(rows.Data);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteSlider(int ID)
        {
            var row = await _Slider.DeleteAsync(ID);
            return Json(row.Returened, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddSlider(int ID)
        {
            return View(ID == 0 ? new Slider() : _Slider.Find(ID).SingleData);
        }

        [HttpPost]
        public async Task<ActionResult> ExecuteSlider(Slider model)
        {
            DbReturned<Slider> Insert_Update;
            if (model.ID == 0)
            {
                Insert_Update = await _Slider.InsertAsync(model);
            }
            else Insert_Update = await _Slider.UpdateAsync(model);
            return Json(Insert_Update.Returened, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteVideo(int ID)
        {
            var row = await _Videos.DeleteAsync(ID);
            return Json(row.Returened, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddVideo(Videos model)
        {
            DbReturned<Videos> Insert_Update;
            if (model.VID == 0)
            {
                Insert_Update = await _Videos.InsertAsync(model);
            }
            else Insert_Update = await _Videos.UpdateAsync(model);


            model.VID = model.VID == 0 ? _Videos.Last().SingleData.VID : model.VID;
            var result = new { Returned = Insert_Update.Returened, Model = model };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion



        #region News

        public async Task<ActionResult> News()
        {
            using (var dc = new TData<AllNews>(conectionString))
            {
                var rows = await dc.SelectAsync(new Entity.Models.StoredProcedure()
                {
                    StoredProcedureName = "GetNews"
                });
                return View(rows.Data);
            }

        }

        [HttpPost]
        public async Task<ActionResult> DeleteNews(int ID)
        {
            var row = await _News.DeleteAsync(ID);
            return Json(row.Returened, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNews(int ID)
        {
            ViewBag.Departments = _Departments.Select().Data;
            return View(ID == 0 ? new App.Models.News() : _News.Find(ID).SingleData);
        }


        [HttpPost]
        public async Task<ActionResult> ExecuteNews(App.Models.News model)
        {
         //   model.CreatedDate = Convert.ToDateTime("2016-08-30 00:00:00.000");
            DbReturned<App.Models.News> Insert_Update;
            if (model.ID == 0)
            {
                Insert_Update = await _News.InsertAsync(model);
            }
            else Insert_Update = await _News.UpdateAsync(model);
            return Json(Insert_Update.Returened, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}