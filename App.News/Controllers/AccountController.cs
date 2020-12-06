using App.Entity.Structs;
using App.Models;
using App.News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.News.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public async Task<ActionResult> LoginUser(Users model)
        {
            try
            {
                var State = await _Users.SelectAsync(new Entity.Models.StoredProcedure()
                {
                    StoredProcedureName = "SearchUser",
                    arr = new System.Collections.ArrayList() { model.UserName, model.Password },
                    Params = new List<string>() { "Name", "Password" }
                });
                if (State.Data.Count == 0)
                {
                    return Json(
                    new Returened()
                    {
                        State = false,
                        ErrorMessage = "لايوجد حساب بهذه المعلومات"
                    });
                }
                _Settings.AddUser(State.Data[0].UserID);
                if (State.Data[0].RoleID == 1)
                {
                    _Settings.AddAdmin(State.Data[0].UserID);
                }
                return Json(State.Returened);
            }
            catch (Exception ex)
            {
                return Json(new Returened() { State = false, ErrorMessage = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}