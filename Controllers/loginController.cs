using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Authorized()
        {
            return View();
        }
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(TBL_SIGNUP userModel)
        {
            using (managementEntities db = new managementEntities())
            {
                var userdetails = db.TBL_SIGNUP.Where(a => a.USER_NAME == userModel.USER_NAME && a.PASSWORD == userModel.PASSWORD).FirstOrDefault();
                if(userdetails !=null)
                {
                    return RedirectToAction("bookregister", "book");
                }
                else
                {
                    ViewBag.message = true;
                    ViewBag.errormessage = "username and password is invalid";
                    return View(userModel);
                    
                }
            }
        }
    }
}