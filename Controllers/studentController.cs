using MVCSample.Models;
using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class studentController : Controller
    {
        private managementEntities db = new managementEntities();
        // GET: student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult student(string FIRST_NAME, string ADDRESS, string DATEOFBIRTH,string PHONE,string AGE,string GENDER,string SEM, string IMAGE)
        {
            int age_ = Convert.ToInt32(AGE);
            int sem_ = Convert.ToInt32(SEM);
            ObjectParameter output = new ObjectParameter("V_OUT", typeof(int));
            var result = db.P_STUDENT(FIRST_NAME, ADDRESS, DATEOFBIRTH, PHONE, age_, GENDER, sem_, IMAGE, output);
            if (result.ToString() == "1")
            {
                ViewBag.message = true;
                ViewBag.errormessage = "unsuccessfully";
            }
            else
            {
                ViewBag.message = true;
                ViewBag.errormessage = "successfully";
            }
            return View();
        }
        public ActionResult studentlist()
        {
            return View(db.P_GET_STUDENT().ToList());
                
        }
    }
}